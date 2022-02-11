using Incubadora.Business.Enum;
using Incubadora.Business.Interface;
using Incubadora.Domain;
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

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        private readonly IProyectoBusiness proyectoBusiness;

        public CalendarizacionController(ISubModuloBusiness _submoduloBusiness, IProyectoBusiness _proyectoBusiness, ISubModuloSesionesProyectoBusiness _SubmoduloBusiness)
        {
            submoduloBusiness = _submoduloBusiness;
            proyectoBusiness = _proyectoBusiness;
            SubmoduloBusiness = _SubmoduloBusiness;
        }
        // GET: Calendarizacion
        public ActionResult Create()
        {
            ViewBag.submodulos = new SelectList(submoduloBusiness.GetSubModulosAll(), "Id", "StrValor");
            ViewBag.proyectos = new SelectList(proyectoBusiness.GetProyectos(), "Id", "StrNombre");
            ViewBag.colores=GetColores();
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

    }
}