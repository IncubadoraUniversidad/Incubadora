using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Incubadora.Business.Enum;
using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Helpers.Exportacion;
using Incubadora.Repository;
using Incubadora.Security;
using Incubadora.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        private readonly IEmprendedorBusiness emprendedorBusiness;

        public ProyectoController(
            IProyectoBusiness _proyectoBusiness,
            IServicioBusiness _servicioBusiness,
            IFaseBusiness _faseBusiness,
            IGiroBusiness _giroBusiness,
            IEmprendedorBusiness _emprendedorBusiness
        )
        {
            proyectoBusiness = _proyectoBusiness;
            servicioBusiness = _servicioBusiness;
            faseBusiness = _faseBusiness;
            giroBusiness = _giroBusiness;
            emprendedorBusiness = _emprendedorBusiness;
        }

        // GET: Proyecto
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Emprendedor")]
        public ActionResult Registro()
        {
            try
            {
                ViewBag.Servicios = new MultiSelectList(servicioBusiness.GetServicios(), "Id", "StrValor");
                ViewBag.Giros = new SelectList(giroBusiness.GetGiros(), "Id", "StrValor");
                ViewBag.Fases = new SelectList(faseBusiness.GetFases(), "Id", "StrValor");
                ViewBag.ConstituidaLegal = GetConstituidaLegalmenteOptions();
                proyectoBusiness.GetProyectoByIdUser(ClaimsPersister.GetUserId());
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
                var emprendedor = emprendedorBusiness.GetEmprendedorByAspNetUserId(ClaimsPersister.GetUserId());
                proyectoDomainModel.IdEmprendedor = emprendedor.Id;
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

        #region TABLA DE PROYECTOS
        [HttpGet]
        public JsonResult GetProyectoGeneral()
        {
            var proyectos = this.proyectoBusiness.GetProyectos();
            return Json(proyectos, JsonRequestBehavior.AllowGet);

        }
        #endregion

       


        #region Exporta la consulta a excel y hace descarga en el dispositivo

        public FileResult Exporta(string Id)
        {
            List<ProyectoDomainModel> proyectitos = proyectoBusiness.GetProyectoByIdNew(Id);
            List<ProyectoVM> proyectos = new List<ProyectoVM>();
                AutoMapper.Mapper.Map(proyectitos, proyectos);
                /// Esta parte tiene que pintar la tabla en excel
                /// 
                DataTable dt = new DataTable();
                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                dt = converter.ToDataTable(proyectos);

                dt.TableName = "Proyectos";
                using (XLWorkbook libro = new XLWorkbook())
                {
                    var hoja = libro.Worksheets.Add(dt);
                    hoja.ColumnsUsed().AdjustToContents();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        libro.SaveAs(ms);
                        return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte" + DateTime.Now.ToString() + ".xlsx");
                    }
                }
            }
        #endregion


        public ActionResult Dashboard()
        {
            return View();
        }

        #region Resultado de los giros Totales el json
        [HttpGet]
        public JsonResult GetEstadisticasEmpresarialesByGiro()
        {
          
            return Json(proyectoBusiness.TotalProyectosGiro(), JsonRequestBehavior.AllowGet);
        }
        #endregion



        #region Resultado de estatus constituidos de los proyectos en json
        [HttpGet]
        public JsonResult GetConstituidosChavoXd()
        {


            return Json(proyectoBusiness.TotalConstituidos(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Retorna el resulta donde tiene el nombre del poryecto y su giro
        [HttpGet]
        public JsonResult Tabla()
        {


            return Json(proyectoBusiness.TablaDeGiros(), JsonRequestBehavior.AllowGet);
        }
        #endregion



    }
}
 