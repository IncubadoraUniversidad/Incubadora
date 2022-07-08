using Incubadora.Business.Enum;
using Incubadora.Business.Interface;
using Incubadora.Domain;
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
    public class CalendarizacionController : Controller

    {
        private readonly ISubModuloBusiness submoduloBusiness;
        private readonly ISubModuloSesionesProyectoBusiness SubmoduloBusiness;
        private readonly ICalendarizacionBusiness calendarizacionBusiness;

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        private readonly IProyectoBusiness proyectoBusiness;

        public CalendarizacionController(ISubModuloBusiness _submoduloBusiness, IProyectoBusiness _proyectoBusiness, ISubModuloSesionesProyectoBusiness _Submodulousiness)
        {
            submoduloBusiness = _submoduloBusiness;
            proyectoBusiness = _proyectoBusiness;
            SubmoduloBusiness = _Submodulousiness;
            //calendarizacionBusiness = _calendarizacionBusiness;
        }
        // GET: Calendarizacion
        public ActionResult Create()
        {
            ViewBag.Role = ClaimsPersister.GetRoleClaim();
            ViewBag.submodulos = new SelectList(submoduloBusiness.GetSubModulosAll(), "Id", "StrValor");
            ViewBag.proyectos = new SelectList(proyectoBusiness.GetProyectos(), "Id", "StrNombre");
            ViewBag.colores = GetColores();
            return View();
        }
        [HttpGet]
        public JsonResult GetSesionesBySubmoduloId(int idSubmodulo)
        {
            return Json(submoduloBusiness.GetSesionesBySubModuloId(idSubmodulo), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubModuloSesionesProyectoVM subModuloSesionesProyectoVM, int idSesiones)
        {
            try
            {
                ViewBag.Role = ClaimsPersister.GetRoleClaim();
                //ActionResult result
                if (ModelState.IsValid)
                {
                    SubModuloSesionesProyectoDomainModel subModuloSesionesProyectoDomainModel = new SubModuloSesionesProyectoDomainModel();
                    AutoMapper.Mapper.Map(subModuloSesionesProyectoVM, subModuloSesionesProyectoDomainModel);
                    subModuloSesionesProyectoDomainModel.IdSesion = idSesiones;
                    var usuario = (subModuloSesionesProyectoDomainModel);
                    SubmoduloBusiness.AddSubModuloSesiones(subModuloSesionesProyectoDomainModel);
                }
                ViewBag.submodulos = new SelectList(submoduloBusiness.GetSubModulosAll(), "Id", "StrValor");
                ViewBag.proyectos = new SelectList(proyectoBusiness.GetProyectos(), "Id", "StrNombre");
                ViewBag.colores = GetColores();
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex, Recursos.Recursos_Sistema.ERROR_LOGIN_FAIL);
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
        private SelectList GetColores()
        {
            var colores = from ColorEnum color in Enum.GetValues(typeof(ColorEnum))
                          select new { StrColorTema = color.ToString() };
            var coloresSelectList = new SelectList(colores, "StrColorTema", "StrColorTema");
            return coloresSelectList;
        }
        [HttpGet]
        public JsonResult GetEventos()
        {
            var eventos = SubmoduloBusiness.GetEventos();
            List<SubModuloSesionesProyectoVM> subModuloSesionesProyectoVM = new List<SubModuloSesionesProyectoVM>();
            AutoMapper.Mapper.Map(eventos, subModuloSesionesProyectoVM);
            return Json(subModuloSesionesProyectoVM, JsonRequestBehavior.AllowGet);
        }

        [ActionName("Calendario")]
        [HttpGet]
        public ActionResult GetCalendario()
        {
            return View();

        }
        [HttpGet]
        public JsonResult Agenda()
        {

            return Json(SubmoduloBusiness.GetEventos(), JsonRequestBehavior.AllowGet);
        }


    }
}