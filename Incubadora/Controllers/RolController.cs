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
    public class RolController : Controller
    {
        private readonly IAspNetRolesBusiness _rolesBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");


        public RolController(IAspNetRolesBusiness rolesBusiness)
        {
            this._rolesBusiness = rolesBusiness;
        }
        
        // GET: Rol
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AspNetRolesVM rolesVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AspNetRolesDomainModel AspNetRolesDM = new AspNetRolesDomainModel();
                    AutoMapper.Mapper.Map(rolesVM, AspNetRolesDM);
                    this._rolesBusiness.AddUpdateRol(AspNetRolesDM);
                }
                return View();
            }
            catch (Exception ex)
            {

                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Rol");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }


        public JsonResult GetRoles()
        {
            var rolesDomainModel = this._rolesBusiness.GetRoles();
            List<AspNetRolesVM> rolesVM = new List<AspNetRolesVM>();
            AutoMapper.Mapper.Map(rolesDomainModel, rolesVM);
            return Json(rolesVM, JsonRequestBehavior.AllowGet);
        }

    }
}