using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Encrypt;
using Incubadora.Security;
using Incubadora.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using NLog;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAspNetRolesBusiness rolesBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IAspNetUsersBusiness usersBusiness;
        public AccountController(IAspNetRolesBusiness _rolesBusiness, IAspNetUsersBusiness _usersBusiness)
        {
            rolesBusiness = _rolesBusiness;
            usersBusiness = _usersBusiness;
        }

        #region Metodos de Insercion
        // GET: Account
        public ActionResult Create()
        {
            try
            {
                ViewBag.Role = ClaimsPersister.GetRoleClaim();
                ViewBag.IdRol = new SelectList(rolesBusiness.GetRoles(), "Id", "Name");
                return View();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Account");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "UserName,PasswordHash")]AspNetUsersVM usersVM,string IdRol)
        {
            try
            {
                AspNetUsersDomainModel usersDomainModel = new AspNetUsersDomainModel();
                AutoMapper.Mapper.Map(usersVM, usersDomainModel);
                AspNetRolesDomainModel rolesDomainModel = new AspNetRolesDomainModel();
                usersDomainModel.Id = Guid.NewGuid().ToString();
                usersDomainModel.PasswordHash=Funciones.Encrypt(usersDomainModel.PasswordHash);
                rolesDomainModel.Id = IdRol;
                usersDomainModel.AspNetRolesDomainModel = rolesDomainModel;
                if (usersBusiness.AddUpdateUser(usersDomainModel))
                {
                    ViewBag.IdRol = new SelectList(rolesBusiness.GetRoles(), "Id", "Name");
                    return View();
                }
                else {
                    Log.Error("Ocurrio una exepcion al intentar guardar el usuario");
                    loggerdb.Error("Error en la insercion del usuario");
                    return RedirectToAction("InternalServerError", "Error");
                }
            }
            catch (System.Exception ex)
            {

                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Account");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
        #endregion

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM loginVM, string returnUrl)
        {
            
            try
            {
                ActionResult result;
                if (ModelState.IsValid)
                {
                    LoginDomainModel loginDomainModel = new LoginDomainModel();
                    AutoMapper.Mapper.Map(loginVM, loginDomainModel);
                    loginDomainModel.PasswordHash = Funciones.Encrypt(loginDomainModel.PasswordHash);
                    var usuario = usersBusiness.ValidateLogin(loginDomainModel);
                    if (usuario != null)
                    {
                        result = SigInUser(usuario, true, returnUrl);
                    }
                    else 
                    {
                        ModelState.AddModelError("error_login",Recursos.Recursos_Sistema.USUARIO_LOGIN_NULL);
                        return View();
                    }
                    return result;
                }
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex, Recursos.Recursos_Sistema.ERROR_LOGIN_FAIL);
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        [HttpGet]
        public ActionResult Perfil()
        {
            ViewBag.Role = ClaimsPersister.GetRoleClaim();
            //se modifico el perfil del usuario
            return View();
        }


        #region Agregar Claims del Usuario
        private ActionResult SigInUser(LoginDomainModel userDM, bool rememberMe, string returnUrl)
        {
            //se crea una variable del tipo ActionResult
            ActionResult Result;
            //un claims puede almacenar cualquier tipo de informacion del usuario, nombre, mail, password, lo que sea
            List<Claim> Claims = new List<Claim>(); //listado de claims
            Claims.Add(new Claim(ClaimTypes.NameIdentifier, userDM.Id.ToString())); //primer claims agregamos el identificador del usuarioQA
            ///Claims.Add(new Claim(ClaimTypes.Email, userDM.Email));//agregamos el email al claim
            Claims.Add(new Claim(ClaimTypes.Name, userDM.UserName));//agregamos el nombre de usuario
            ///estos claims se almacenan en la cookie para identificar al usuario y sus atributos o permisos
            //ahora establecemos los claims con los roles del usuario
            if (userDM.aspNetRoles != null)
            {
                Claims.Add( new Claim(ClaimTypes.Role, userDM.aspNetRoles.Name));
            }
            var Identity = new ClaimsIdentity(Claims, DefaultAuthenticationTypes.ApplicationCookie); //entonces ahora creamos una identidad basada en claims con sus roles permisos y nombre del usuario
            ///cuando el usuario se logea se crea una cookie de autenticacion 
            //este AutenticationManager se encarga de administrarla cookie y da el seguimiento a todo el sitio con todo y los permisos del usuario
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = rememberMe }, Identity); //el rememberMe es para recordarlo true/false
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Url.Action("Registro", "Emprendedor");
            }
            Result = Redirect(returnUrl);
            return Result;
        }
        #endregion

        #region Logout de la aplicación
        public ActionResult LogOff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Metodos de Consulta
        [HttpGet]
        public JsonResult GetUsuarios()
        {
            try
            {
                var usuariosVM = new List<AspNetUsersVM>();
                var usuariosDM = usersBusiness.GetUserRoles();
                AutoMapper.Mapper.Map(usuariosDM,usuariosVM);
                return Json(usuariosVM, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Account");
                loggerdb.Error(ex);
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON,JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}