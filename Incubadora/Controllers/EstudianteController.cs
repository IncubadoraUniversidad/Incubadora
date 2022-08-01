﻿using Incubadora.Business;
using Incubadora.Business.Enum;
using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Encrypt;
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
    [Authorize(Roles = "Administrador")]
    public class EstudianteController : Controller
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IEstudianteBusiness estudianteBusiness;
        private readonly IStatusBusiness statusBusiness;
        private readonly IPeriodoEstadiaBusiness periodoEstadiaBusiness;
        private readonly IGrupoBusiness grupoBusiness;
        private readonly IUnidadAcademicaBusiness unidadAcademicaBusiness;
        private readonly IAspNetUsersBusiness aspNetUsersBusiness;
        private readonly IAspNetRolesBusiness aspNetRolesBusiness;
        private readonly ICarreraBusiness carreraBusiness;

        public EstudianteController(IEstudianteBusiness _estudianteBusiness,
            IStatusBusiness _statusBusiness,
            IPeriodoEstadiaBusiness _periodoEstadiaBusiness,
            IUnidadAcademicaBusiness _unidadAcademicaBusiness,
            IGrupoBusiness _grupoBusiness,
            IAspNetUsersBusiness _aspNetUsersBusiness,
            IAspNetRolesBusiness _aspNetRolesBusiness,
            ICarreraBusiness _carreraBusiness)
        {
            estudianteBusiness = _estudianteBusiness;
            statusBusiness = _statusBusiness;
            periodoEstadiaBusiness = _periodoEstadiaBusiness;
            unidadAcademicaBusiness = _unidadAcademicaBusiness;
            grupoBusiness = _grupoBusiness;
            aspNetUsersBusiness = _aspNetUsersBusiness;
            aspNetRolesBusiness = _aspNetRolesBusiness;
            carreraBusiness = _carreraBusiness;
        }

        // GET: Estudiante
        public ActionResult Index()
        {
            return RedirectToAction("InternalServerError", "Error");
        }

        // Get: Retorna la vista del fomrulario de estudiante
        //[Authorize(Roles = "Administrador, Emprendedor")]
        [HttpGet]
        public ActionResult Registro()
        {
            ViewBag.IdPeriodoEstadia = new SelectList(periodoEstadiaBusiness.GetPeriodos(), "Id", "StrValor");
            ViewBag.IdGrupo = new SelectList(grupoBusiness.GetGrupos(), "Id", "StrValor");
            ViewBag.IdStatus = new SelectList(statusBusiness.GetStatusEmprendimiento(), "Id", "StrValor");
            ViewBag.IdUnidadAcademica = new SelectList(unidadAcademicaBusiness.GetAll(), "Id", "StrValor");
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Administrador, Emprendedor")]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(EstudianteVM estudianteVM)
        {
            try
            {
                //estudianteVM.IdCarrera = IdCarrera;
                EstudianteDomainModel estudianteDomainModel = new EstudianteDomainModel();
                
                AutoMapper.Mapper.Map(estudianteVM, estudianteDomainModel);
                if (estudianteBusiness.Add(estudianteDomainModel))
                {
                    ViewBag.IdPeriodoEstadia = new SelectList(periodoEstadiaBusiness.GetPeriodos(), "Id", "StrValor");
                    ViewBag.IdGrupo = new SelectList(grupoBusiness.GetGrupos(), "Id", "StrValor");
                    ViewBag.IdStatus = new SelectList(statusBusiness.GetStatusEmprendimiento(), "Id", "StrValor");
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
                Log.Error(ex, "Ocurrió una exepción en el método registro del controlador Estudiante");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }

        [HttpGet]
        [Route(Name ="/Estudiante/Perfil")]
        //[Authorize(Roles = "Administrador,Emprendedor")]
        public ActionResult Profiles()
        {
            ViewBag.Role = ClaimsPersister.GetRoleClaim();
            
            return View();
        }

        [HttpGet]
        public JsonResult GetEstudiantes()
        {
            var estudiantes = estudianteBusiness.GetEstudiantes();

            return Json(estudiantes, JsonRequestBehavior.AllowGet);
        }

        #region Edicion de Estudiante
        [HttpGet]
        public ActionResult AddEditDatosEstudiante(string Id)
        {
            //objeto que vamos a regresar en la vista modal
            EstudianteVM estudianteVM = new EstudianteVM();
            //creamos el objeto del dominio
            EstudianteDomainModel estudianteDM = new EstudianteDomainModel();

            if (!string.IsNullOrEmpty(Id))
            {
                estudianteDM = estudianteBusiness.GetEstudianteById(Id);
            }

            AutoMapper.Mapper.Map(estudianteDM, estudianteVM);
            return PartialView("_Editar", estudianteVM);
        }
        #endregion

        #region Actualizar Estudiante
        [HttpPost]
        [Authorize(Roles = "Administrador,Emprendedor")]
        public ActionResult Editar(EstudianteVM estudianteVM)
        {
            try
            {
                EstudianteDomainModel estudianteDM = new EstudianteDomainModel();
                AutoMapper.Mapper.Map(estudianteVM, estudianteDM);
                if (!string.IsNullOrEmpty(estudianteVM.Id) && ModelState.IsValid)
                {
                    estudianteBusiness.UpdateEstudiante(estudianteDM);
                }
                return RedirectToAction("Profiles", "Estudiante");
            }
            catch (Exception ex)
            {
                Log.Error(ex, Recursos.Recursos_Sistema.ERROR_DELETE_PROYECTO_CONTROLADOR);
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }

        }
        #endregion

        #region Consultar Estudiante a Eliminar
        public ActionResult AddDeleteEstudiante(string Id)
        {
            //objeto que vamos a regresar en la vista modal
            EstudianteVM estudianteVM = new EstudianteVM();
            //creamos el objeto del dominio
            EstudianteDomainModel estudianteDM = new EstudianteDomainModel();
            if (!string.IsNullOrEmpty(Id))
            {
                estudianteDM = estudianteBusiness.GetEstudianteById(Id);
            }

            AutoMapper.Mapper.Map(estudianteDM, estudianteVM);
            return PartialView("_Eliminar", estudianteVM);
        }
        #endregion

        #region Eliminacion de un Estudiante
        [HttpPost]
        public ActionResult Eliminar(string Id)
        {
            try
            {
                estudianteBusiness.DeleteEstudiante(Id);
                return RedirectToAction("Profiles", "Estudiante");
            }
            catch (Exception ex)
            {
                Log.Error(ex, Recursos.Recursos_Sistema.ERROR_DELETE_PROYECTO_CONTROLADOR);
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }
        #endregion
    }
}