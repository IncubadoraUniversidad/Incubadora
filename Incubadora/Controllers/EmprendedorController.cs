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
    public class EmprendedorController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IEmprendedorBusiness emprendedorBusiness;
        private readonly IEstadoBusiness estadoBusiness;
        private readonly ICuatrimestreBusiness cuatrimestreBusiness;
        private readonly IUnidadAcademicaBusiness unidadAcademicaBusiness;

        public EmprendedorController(
            IEmprendedorBusiness _emprendedorBusiness,
            IEstadoBusiness _estadoBusiness,
            ICuatrimestreBusiness _cuatrimestreBusiness,
            IUnidadAcademicaBusiness _unidadAcademicaBusiness
        )
        {
            emprendedorBusiness = _emprendedorBusiness;
            estadoBusiness = _estadoBusiness;
            cuatrimestreBusiness = _cuatrimestreBusiness;
            unidadAcademicaBusiness = _unidadAcademicaBusiness;
        }

        // GET: Emprendedor
        public ActionResult Index()
        {
            return View();
        }

        // Get: Retorna la vista del fomrulario de emprendedor
        public ActionResult Registro()
        {
            try
            {

                ViewBag.IntOcupacion = GetOcupaciones();
                ViewBag.IdEstado = new SelectList(estadoBusiness.GetEstados(), "Id", "StrNombre");
                ViewBag.IdCuatrimestre = new SelectList(cuatrimestreBusiness.GetAll(), "Id", "StrValor");
                ViewBag.IdUnidadAcademica = new SelectList(unidadAcademicaBusiness.GetAll(), "Id", "StrValor");
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método registro del controlador Emprendedor");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(EmprendedorVM emprendedorVM, int IdMunicipio, int IdColonia, string IdCarrera)
        {
            try
            {
                // emprendedorVM.Direccion.IdEstado = emprendedorVM.Direccion.IdEstado;
                emprendedorVM.Direccion.IdMunicipio = IdMunicipio;
                emprendedorVM.Direccion.IdColonia = IdColonia;
                // emprendedorVM.DatoLaboral.IdUnidadAcademica = IdUnidadAcademica;
                emprendedorVM.DatoLaboral.IdCarrera = IdCarrera;
                // emprendedorVM.DatoLaboral.IdCuatrimestre = IdCuatrimestre;
                EmprendedorDomainModel emprendedorDomainModel = new EmprendedorDomainModel();
                AutoMapper.Mapper.Map(emprendedorVM, emprendedorDomainModel);
                if (emprendedorBusiness.Add(emprendedorDomainModel))
                {
                    ViewBag.IntOcupacion = GetOcupaciones();
                    ViewBag.IdEstado = new SelectList(estadoBusiness.GetEstados(), "Id", "StrNombre");
                    ViewBag.IdCuatrimestre = new SelectList(cuatrimestreBusiness.GetAll(), "Id", "StrValor");
                    ViewBag.IdUnidadAcademica = new SelectList(unidadAcademicaBusiness.GetAll(), "Id", "StrValor");
                    return View();
                }
                else
                {
                    Log.Error("Ocurrió una exepción al intentar guardar el emprendedor");
                    loggerdb.Error("Error en la inserción del usuario");
                    return RedirectToAction("InternalServerError", "Error");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió una exepción en el método registro del controlador Emprendedor");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        private SelectList GetOcupaciones()
        {
            var ocupaciones = from OcupacionEnum ocupacion in Enum.GetValues(typeof(OcupacionEnum))
                              select new { IntOcupacion = (int)ocupacion, StrValor = ocupacion.ToString() };
            var ocupacionesSelectList = new SelectList(ocupaciones, "IntOcupacion", "StrValor");
            return ocupacionesSelectList;
        }
    }
}