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
    public class RecursoProyectoController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IRecursoBusiness recursoBusiness;

        public RecursoProyectoController(IRecursoBusiness _recursoBusiness)
        {
            recursoBusiness = _recursoBusiness;
        }
        // GET: RecursoProyecto
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Emprendedor")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Emprendedor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecursoVM recursoVM)
        {
            try
            {
                RecursoDomainModel recursoDomainModel = new RecursoDomainModel();
                AutoMapper.Mapper.Map(recursoVM, recursoDomainModel);
                recursoDomainModel.IdUsuario = ClaimsPersister.GetUserId();
                if (recursoBusiness.Add(recursoDomainModel))
                {
                    return RedirectToAction("GetAll");
                }
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método create(Post) del controlador RecursoProyecto");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
        public ActionResult GetAll()
        {
            return View("Recursos");
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            var recurso = recursoBusiness.GetRecursoById(Id);
            RecursoVM recursoVM = new RecursoVM();
            AutoMapper.Mapper.Map(recurso, recursoVM);
            return PartialView("_Editar", recursoVM);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Emprendedor")]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(RecursoVM recursoVM)
        {
            try
            {
                recursoVM.IdUsuario = ClaimsPersister.GetUserId();
                RecursoDomainModel recursoDomainModel = new RecursoDomainModel();
                AutoMapper.Mapper.Map(recursoVM, recursoDomainModel);
                recursoBusiness.Update(recursoDomainModel);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método editar(Post) del controlador RecursoProyecto");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        public ActionResult Delete(string Id)
        {
            var recurso = recursoBusiness.GetRecursoById(Id);
            RecursoVM recursoVM = new RecursoVM();
            AutoMapper.Mapper.Map(recurso, recursoVM);
            return PartialView("_Eliminar", recursoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Emprendedor")]
        public ActionResult Eliminar(RecursoVM recursoVM)
        {
            try
            {
                recursoBusiness.Delete(recursoVM.Id);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método Eliminar(Post) del controlador RecursoProyecto");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        [HttpGet]
        public JsonResult GetRecursos()
        {
            try
            {
                var recursos = recursoBusiness.GetRecursosByUserId(ClaimsPersister.GetUserId());
                List<RecursoVM> recursosVM = new List<RecursoVM>();
                AutoMapper.Mapper.Map(recursos, recursosVM);
                return Json(recursos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método GetRecursos(Post) del controlador RecursoProyecto");
                loggerdb.Error(ex);
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON, JsonRequestBehavior.AllowGet);
            }

        }
    }
}