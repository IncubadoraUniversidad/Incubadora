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
    public class StatusController : Controller
    {
        private readonly IStatusBusiness statusBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        public StatusController(IStatusBusiness _statusBusiness)
        {
            this.statusBusiness = _statusBusiness;
        }

        // GET: Status
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StatusVM statusVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StatusDomainModel StatusDM = new StatusDomainModel();
                    if (!this.statusBusiness.ValidateStatusValue(statusVM.StrValor))
                    {
                        AutoMapper.Mapper.Map(statusVM, StatusDM);
                        this.statusBusiness.AddUpdateStatus(StatusDM);
                        return RedirectToAction("Create", "Status");
                    }
                    ModelState.AddModelError("StrValor", "Ha ocurrido un error, el campo ya existe");
                    return View();
                }
                return View();
            }catch(Exception ex)
            {
                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Rol");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
        public JsonResult GetStatus()
        {
            var statusDomainModel = this.statusBusiness.GetStatus();
            List<StatusVM> statusVM = new List<StatusVM>();
            AutoMapper.Mapper.Map(statusDomainModel, statusVM);
            return Json(statusVM, JsonRequestBehavior.AllowGet);
        }
    }
}