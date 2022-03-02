using Incubadora.Business.Enum;
using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Encrypt;
using Incubadora.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class DocenteController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IAspNetUsersBusiness aspNetUsersBusiness;
        private readonly IAspNetRolesBusiness aspNetRolesBusiness;
        private readonly IDocenteBusiness docenteBusiness;

        public DocenteController(
            IAspNetUsersBusiness _aspNetUsersBusiness,
            IAspNetRolesBusiness _aspNetRolesBusiness,
            IDocenteBusiness _docenteBusiness
        )
        {
            aspNetUsersBusiness = _aspNetUsersBusiness;
            aspNetRolesBusiness = _aspNetRolesBusiness;
            docenteBusiness = _docenteBusiness;
        }

        // GET: Docente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            ViewBag.Sexos = GetSexos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(DocenteVM docenteVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Sexos = GetSexos();
                    return View(docenteVM);
                }
                var docenteRol = aspNetRolesBusiness.GetRoles().FirstOrDefault(rol => rol.Name == "Docente");
                DocenteDomainModel docenteDM = new DocenteDomainModel();
                AutoMapper.Mapper.Map(docenteVM, docenteDM);
                docenteDM.AspNetUserDomainModel.PasswordHash = Funciones.Encrypt(docenteDM.AspNetUserDomainModel.PasswordHash);
                if (docenteBusiness.Add(docenteDM, docenteRol.Id))
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    Log.Error("Ocurrio una exepcion al intentar registrar un docente en AspNetUsers");
                    loggerdb.Error("Error en la insercion del usuario con rol docente");
                    return RedirectToAction("InternalServerError", "Error");
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex, "Ocurrió una excepción en el método registro(post) del controlador Docente");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        private SelectList GetSexos()
        {
            var sexos = from SexoEnum sexo in Enum.GetValues(typeof(SexoEnum))
                              select new { IdSexo = (int)sexo, StrValor = sexo.ToString() };
            var sexoSelectList = new SelectList(sexos, "IdSexo", "StrValor");
            return sexoSelectList;
        }
    }
}