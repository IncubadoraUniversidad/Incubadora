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

        public EmprendedorController(IEmprendedorBusiness _emprendedorBusiness)
        {
            emprendedorBusiness = _emprendedorBusiness;
        }

        // GET: Emprendedor
        public ActionResult Index()
        {
            return View();
        }

        // Get: Retorna la vista del fomrulario de emprendedor
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(EmprendedorVM emprendedorVM)
        {
            try
            {
                emprendedorVM.Direccion.IdEstado = new Guid("4B7CFCE3-A43D-442D-AE3F-FBC5E134994D");
                emprendedorVM.Direccion.IdMunicipio = new Guid("E56A9492-0523-4C98-AFFC-E2AC76507F57");
                emprendedorVM.Direccion.IdColonia = new Guid("A019F04A-DC6D-427D-8362-543A6FBF396E");
                emprendedorVM.DatoLaboral.IdUnidadAcademica = new Guid("5F88A149-E5BE-4CB0-9E77-4410FD8B5593");
                emprendedorVM.DatoLaboral.IdCarrera = new Guid("8FED0385-7CA4-4309-9B48-C84E990861AC");
                emprendedorVM.DatoLaboral.IdCuatrimestre = new Guid("C360ACE7-F6D8-432E-BFA7-2BBBEF3761F2");
                EmprendedorDomainModel emprendedorDomainModel = new EmprendedorDomainModel();
                AutoMapper.Mapper.Map(emprendedorVM, emprendedorDomainModel);
                if (emprendedorBusiness.Add(emprendedorDomainModel))
                {
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
    }
}