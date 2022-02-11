using Incubadora.Business.Enum;
using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Encrypt;
using Incubadora.Security;

using Incubadora.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class EmprendedorController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IEmprendedorBusiness emprendedorBusiness;
        private readonly IProyectoBusiness proyectoBusiness;
        private readonly IEstadoBusiness estadoBusiness;
        private readonly ICuatrimestreBusiness cuatrimestreBusiness;
        private readonly IUnidadAcademicaBusiness unidadAcademicaBusiness;
        private readonly IAspNetUsersBusiness aspNetUsersBusiness;
        private readonly IAspNetRolesBusiness aspNetRolesBusiness;

        public EmprendedorController(
            IEmprendedorBusiness _emprendedorBusiness,
            IEstadoBusiness _estadoBusiness,
            ICuatrimestreBusiness _cuatrimestreBusiness,
            IUnidadAcademicaBusiness _unidadAcademicaBusiness,
            IAspNetUsersBusiness _aspNetUsersBusiness,
            IAspNetRolesBusiness _aspNetRolesBusiness,
            IProyectoBusiness _proyectoBusiness
        )
        {
            emprendedorBusiness = _emprendedorBusiness;
            estadoBusiness = _estadoBusiness;
            cuatrimestreBusiness = _cuatrimestreBusiness;
            unidadAcademicaBusiness = _unidadAcademicaBusiness;
            aspNetUsersBusiness = _aspNetUsersBusiness;
            aspNetRolesBusiness = _aspNetRolesBusiness;
            proyectoBusiness = _proyectoBusiness;

        }

        // GET: Emprendedor
        public ActionResult Index()
        {
            return RedirectToAction("InternalServerError", "Error");
        }

        // Get: Retorna la vista del fomrulario de emprendedor
        [Authorize(Roles = "Administrador, Emprendedor, Docente")]
        public ActionResult Registro()
        {
            try
            {

                ViewBag.IntOcupacion = GetOcupaciones();
                ViewBag.IdEstado = new SelectList(estadoBusiness.GetEstados(), "Id", "StrNombre");
                ViewBag.IdCuatrimestre = new SelectList(cuatrimestreBusiness.GetAll(), "Id", "StrValor");
                ViewBag.IdUnidadAcademica = new SelectList(unidadAcademicaBusiness.GetAll(), "Id", "StrValor");
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método registro del controlador Emprendedor");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Emprendedor")]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(EmprendedorVM emprendedorVM, int IdMunicipio, int IdColonia, string IdCarrera)
        {
            try
            {
                // emprendedorVM.Direccion.IdEstado = emprendedorVM.Direccion.IdEstado;
                emprendedorVM.DireccionVM.IdMunicipio = IdMunicipio;
                emprendedorVM.DireccionVM.IdColonia = IdColonia;
                // emprendedorVM.DatoLaboral.IdUnidadAcademica = IdUnidadAcademica;
                emprendedorVM.DatoLaboralVM.IdCarrera = IdCarrera;
                // emprendedorVM.DatoLaboral.IdCuatrimestre = IdCuatrimestre;
                emprendedorVM.IdUsuario = ClaimsPersister.GetUserId();
                EmprendedorDomainModel emprendedorDomainModel = new EmprendedorDomainModel();
                AutoMapper.Mapper.Map(emprendedorVM, emprendedorDomainModel);
                if (emprendedorBusiness.Add(emprendedorDomainModel))
                {
                    ViewBag.IntOcupacion = GetOcupaciones();
                    ViewBag.IdEstado = new SelectList(estadoBusiness.GetEstados(), "Id", "StrNombre");
                    ViewBag.IdCuatrimestre = new SelectList(cuatrimestreBusiness.GetAll(), "Id", "StrValor");
                    ViewBag.IdUnidadAcademica = new SelectList(unidadAcademicaBusiness.GetAll(), "Id", "StrValor");
                    return View();
                }
                else
                {
                    Log.Error("Ocurrió una exepción al intentar guardar el emprendedor");
                    loggerdb.Error("Error en la inserción del usuario");
                    return RedirectToAction("InternalServerError", "Error");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método registro del controlador Emprendedor");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Este método se encarga de registrar a un usuario para la autenticación del sistema
        /// Se registra en la tabla AspNetUser con el Rol de Emprendedor, este registro es únicamente
        /// para manejar el esquema de seguridad (login, logout, claims, roles).
        /// Báscamente damos de alta un nuevo usuario en el sistema con el rol de emprendedor.
        /// </summary>
        /// <returns></returns>
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AspNetUsersVM aspNetUserVM)
        {
            try
            {
                var emprendedorRol = aspNetRolesBusiness.GetRoles().FirstOrDefault(rol => rol.Name == "Emprendedor");
                AspNetUsersDomainModel usersDomainModel = new AspNetUsersDomainModel();
                AutoMapper.Mapper.Map(aspNetUserVM, usersDomainModel);
                AspNetRolesDomainModel rolesDomainModel = new AspNetRolesDomainModel();
                usersDomainModel.Id = Guid.NewGuid().ToString();
                usersDomainModel.PasswordHash = Funciones.Encrypt(usersDomainModel.PasswordHash);
                rolesDomainModel.Id = emprendedorRol.Id;
                usersDomainModel.AspNetRolesDomainModel = rolesDomainModel;
                usersDomainModel.IdAvatar = (int)AvatarEnum.User;
                if (aspNetUsersBusiness.AddUpdateUser(usersDomainModel))
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    Log.Error("Ocurrio una exepcion al intentar guardar el usuario");
                    loggerdb.Error("Error en la insercion del usuario");
                    return RedirectToAction("InternalServerError", "Error");
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex, "Ocurrió una excepción en el método create(post) del controlador Emprendedor");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        private SelectList GetOcupaciones()
        {
            var ocupaciones = from OcupacionEnum ocupacion in Enum.GetValues(typeof(OcupacionEnum))
                              select new { IntOcupacion = (int)ocupacion, StrValor = ocupacion.ToString() };
            var ocupacionesSelectList = new SelectList(ocupaciones, "IntOcupacion", "StrValor");
            return ocupacionesSelectList;
        }

        [HttpGet]
        [Authorize(Roles ="Administrador,Emprendedor")]
        public ActionResult Profiles()
        {
            ViewBag.Role = ClaimsPersister.GetRoleClaim();
            
            var emprendedores = emprendedorBusiness.GetProyectoEmprendedores();
            List<ProyectoVM> proyectos = new List<ProyectoVM>();
            AutoMapper.Mapper.Map(emprendedores, proyectos);
            return View(proyectos);
        }


        [HttpGet]
        public JsonResult GetEmprendedoresProyectos()
        {
            var emprendedores = emprendedorBusiness.GetProyectoEmprendedores();
            return Json(emprendedores,JsonRequestBehavior.AllowGet);
        }

        #region Edicion de Emprendedor Proyecto
        [HttpGet]
        public ActionResult AddEditDatosProyectoEmprendedor(string Id)
        {
            //objeto que vamos a regresar en la vista modal
            ProyectoVM proyectoVM = new ProyectoVM();
            //creamos el objeto del dominio
            ProyectoDomainModel proyectoDM = new ProyectoDomainModel();
            if (!string.IsNullOrEmpty(Id))
            {
                proyectoDM  = proyectoBusiness.GetProyectoEmprendedorById(Id);
            }
          
            AutoMapper.Mapper.Map(proyectoDM, proyectoVM);
            return PartialView("_Editar", proyectoVM);
        }
        #endregion

        
    }
}