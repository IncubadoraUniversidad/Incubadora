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
    public class ColoniaController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IColoniaBusiness coloniaBusiness;

        public ColoniaController(IColoniaBusiness _coloniaBusiness)
        {
            coloniaBusiness = _coloniaBusiness;
        }

        // GET: Colonia
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetColoniasByMunicipioId(int idMunicipio)
        {
            try
            {
                var coloniasVM = new List<ColoniaVM>();
                var coloniasDM = coloniaBusiness.GetColoniasByMunicipioId(idMunicipio);
                AutoMapper.Mapper.Map(coloniasDM, coloniasVM);
                return Json(coloniasVM, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método GetColoniasByMunicipioId del controlador Colonia");
                loggerdb.Error(ex);
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON, JsonRequestBehavior.AllowGet);
            }
        }
    }
}