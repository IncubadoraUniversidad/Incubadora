using Incubadora.Business.Interface;
using Incubadora.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class CarreraController : Controller
    {
        /// <summary>
        /// Documentando una prueba
        /// </summary>
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly ICarreraBusiness carreraBusiness;

        public CarreraController(ICarreraBusiness _carreraBusiness)
        {
            carreraBusiness = _carreraBusiness;
        }

        // GET: Carrera
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCarrerasByUnidadAcademicaId(string unidadAcademicaId)
        {
            try
            {
                var carrerasVM = new List<CarreraVM>();
                var carrerasDM = carreraBusiness.GetCarrerasByUnidadAcademicaId(unidadAcademicaId);
                AutoMapper.Mapper.Map(carrerasDM, carrerasVM);
                return Json(carrerasVM, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrio una exepcion en el metodo GetCarrerasByUnidadAcademicaId del controlador Carrera");
                loggerdb.Error(ex);
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON, JsonRequestBehavior.AllowGet);
            }
        }
    }
}