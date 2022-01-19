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
    public class UnidadAcademicaController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IUnidadAcademicaBusiness unidadAcademicaBusiness;

        public UnidadAcademicaController(IUnidadAcademicaBusiness _unidadAcademicaBusiness)
        {
            unidadAcademicaBusiness = _unidadAcademicaBusiness;
        }

        // GET: UnidadAcademica
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUnidadesAcademicas()
        {
            try
            {
                var unidadesAcademicasVM = new List<UnidadAcademicaVM>();
                var unidadesAcademicasDM = unidadAcademicaBusiness.GetAll();
                AutoMapper.Mapper.Map(unidadesAcademicasDM, unidadesAcademicasVM);
                return Json(unidadesAcademicasVM, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrio una exepcion en el metodo GetUnidadesAcademicas del controlador UnidadAcademica");
                loggerdb.Error(ex);
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON, JsonRequestBehavior.AllowGet);
            }
        }
    }
}