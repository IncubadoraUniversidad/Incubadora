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
    public class MunicipioController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IMunicipioBusiness municipioBusiness;

        public MunicipioController(IMunicipioBusiness _municipioBusiness)
        {
            municipioBusiness = _municipioBusiness;
        }

        // GET: Municipio
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMunicipiosByEstadoId(int idEstado)
        {
            try
            {
                var municipiosVM = new List<MunicipioVM>();
                var municipiosDM = municipioBusiness.GetMunicipiosByEstadoId(idEstado);
                AutoMapper.Mapper.Map(municipiosDM, municipiosVM);
                return Json(municipiosVM, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrio una exepcion en el metodo GetMunicipiosByEstadoId del controlador Municipio");
                loggerdb.Error(ex);
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON, JsonRequestBehavior.AllowGet);
            }
        }
    }
}