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
    public class ProyectoController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IProyectoBusiness proyectoBusiness;
        private readonly IServicioBusiness servicioBusiness;
        private readonly IFaseBusiness faseBusiness;
        private readonly IGiroBusiness giroBusiness;
        
        public ProyectoController(
            IProyectoBusiness _proyectoBusiness,
            IServicioBusiness _servicioBusiness,
            IFaseBusiness _faseBusiness,
            IGiroBusiness _giroBusiness
            
        )
        {
            proyectoBusiness = _proyectoBusiness;
            servicioBusiness = _servicioBusiness;
            faseBusiness = _faseBusiness;
            giroBusiness = _giroBusiness;
           
        }

        // GET: Proyecto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            try
            {
                ViewBag.Servicios = new MultiSelectList(servicioBusiness.GetServicios(), "Id", "StrValor");
                ViewBag.Giros = new SelectList(giroBusiness.GetGiros(), "Id", "StrValor");
                ViewBag.Fases = new SelectList(faseBusiness.GetFases(), "Id", "StrValor");
                ViewBag.ConstituidaLegal = GetConstituidaLegalmenteOptions();
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método registro(get) del controlador Proyecto");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

       
        [HttpPost]
        public JsonResult Registro(ProyectoVM proyectoVM)
        {
            try
            {
                ProyectoDomainModel proyectoDomainModel = new ProyectoDomainModel();
                AutoMapper.Mapper.Map(proyectoVM, proyectoDomainModel);
                proyectoDomainModel.IdEmprendedor = "127a5dc7-0a8d-4faf-b17d-bb349dcac0e2";
                if (proyectoBusiness.Add(proyectoDomainModel))
                {
                    return Json(new { ok = true, message = "Se Registró correctamente" }, JsonRequestBehavior.AllowGet);
                }
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método Registro(post) del controlador Proyecto");
                loggerdb.Error(ex);
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON, JsonRequestBehavior.AllowGet);
            }
        }

        private SelectList GetConstituidaLegalmenteOptions()
        {
            var opciones = from ConstituidaLegalEnum ocupacion in Enum.GetValues(typeof(ConstituidaLegalEnum))
                              select new { IntConstituidaLegal = (int)ocupacion, StrValor = ocupacion.ToString() };
            var opcionesSelectList = new SelectList(opciones, "IntConstituidaLegal", "StrValor");
            return opcionesSelectList;
        }

        #region Eliminacion de un Proyecto
        [HttpPost]
        public ActionResult Eliminar(string Id)
        {
            try
            {
                proyectoBusiness.DeleteProyecto(Id);
                return RedirectToAction("Profiles","Emprendedor");
            }
            catch (Exception ex)
            {
                Log.Error(ex, Recursos.Recursos_Sistema.ERROR_DELETE_PROYECTO_CONTROLADOR);
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
        #endregion

        #region Actualizar Proyecto
        [HttpPost]
        [Authorize(Roles = "Administrador,Emprendedor")]
        public ActionResult Editar(ProyectoVM proyectoVM)
        {
            try
            {
                ProyectoDomainModel proyectoDM = new ProyectoDomainModel();
                AutoMapper.Mapper.Map(proyectoVM, proyectoDM);
                if (!string.IsNullOrEmpty(proyectoVM.Id) && ModelState.IsValid)
                {
                    proyectoBusiness.UpdateProyecto(proyectoDM);                    
                }
                return RedirectToAction("Profiles", "Emprendedor");
            }
            catch (Exception ex)
            {
                Log.Error(ex, Recursos.Recursos_Sistema.ERROR_DELETE_PROYECTO_CONTROLADOR);
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
            
        }
        #endregion

        #region ConsulatrProyectoEmprendedor a Eliminar
        public ActionResult AddDeleteProyectoEmprendedor(string Id)
        {
            //objeto que vamos a regresar en la vista modal
            ProyectoVM proyectoVM = new ProyectoVM();
            //creamos el objeto del dominio
            ProyectoDomainModel proyectoDM = new ProyectoDomainModel();
            if (!string.IsNullOrEmpty(Id))
            {
                proyectoDM = proyectoBusiness.GetProyectoById(Id);
            }

            AutoMapper.Mapper.Map(proyectoDM, proyectoVM);
            return PartialView("_Eliminar", proyectoVM);
        }
        #endregion
    }
}