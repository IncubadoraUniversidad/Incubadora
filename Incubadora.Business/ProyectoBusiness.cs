using Incubadora.Business.Enum;
using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Incubadora.Business
{
    public class ProyectoBusiness : IProyectoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly GiroRepository giroRepository;
        private readonly ProyectoRepository repository;
        public ProyectoBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new ProyectoRepository(this.unitOfWork);
            giroRepository = new GiroRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de insertar en cascade un Proyecto en base de datos
        /// Las entidades (tablas) que inserta en cascada son:
        /// ServiciosUniversitarios y RecursosProyectos
        /// </summary>
        /// <param name="proyectoDomainModel">Un objeto de tipo ProyectoDomainModel que contiene todos los datos</param>
        /// <returns>True si fue registrado, false si no</returns>
        public bool Add(ProyectoDomainModel proyectoDomainModel)
        {
            var serviciosUniversitarios = new List<ServiciosUniversitarios>();
            foreach (var servicioUniversitario in proyectoDomainModel.ServiciosUniversitariosDomainModel)
            {
                serviciosUniversitarios.Add(new ServiciosUniversitarios {
                    Id = Guid.NewGuid().ToString(),
                    IdServicio = servicioUniversitario.IdServicio
                });
            }
            var recursosProyectos = new List<RecursosProyectos>();
            foreach (var recursoProyecto in proyectoDomainModel.RecursosProyectosDomainModel)
            {
                recursosProyectos.Add(new RecursosProyectos {
                    Id = Guid.NewGuid().ToString(),
                    IdProyecto = recursoProyecto.IdProyecto,
                    IdRecurso = recursoProyecto.IdRecurso,
                });
            }
            var proyecto = new Proyectos
            {
                Id = Guid.NewGuid().ToString(),
                IdEmprendedor = proyectoDomainModel.IdEmprendedor,
                IdFase = proyectoDomainModel.IdFase,
                IdGiro = proyectoDomainModel.IdGiro,
                IntConstituidaLegal = proyectoDomainModel.IntConstituidaLegal,
                DtFechaRegistro = proyectoDomainModel.DtFechaRegistro,
                StrDescripcion = proyectoDomainModel.StrDescripcion,
                StrNombre = proyectoDomainModel.StrNombre,
                StrNombreEmpresa = proyectoDomainModel.StrNombreEmpresa,
                StrObservaciones = proyectoDomainModel.StrObservaciones,
                StrRFC = proyectoDomainModel.StrRFC,
                RecursosProyectos = recursosProyectos,
                ServiciosUniversitarios = serviciosUniversitarios,
                IdStatus = (int)Enum.StatusEnum.Activo
                //      IdStatus = 10

            };
            var proyectodb = repository.Insert(proyecto);
            return proyectodb != null;
        }

        /// <summary>
        /// Este metodo se encarga de consultar un proyecto en especifico por Id y su emprendedor
        /// </summary>
        /// <param name="Id">el identificador del emprendedor</param>
        /// <returns>la entidad del tipo ProyectoDomainModel</returns>
        public ProyectoDomainModel GetProyectoEmprendedorById(string Id)
        {
            ProyectoDomainModel proyectoDM = null;
            var proyecto = repository.SingleOrDefaultInclude(p => p.Id == Id, Recursos.CatalogosEntidades.Emprendedores);
            if (proyecto != null)
            {
                proyectoDM = new ProyectoDomainModel
                {
                    Id = proyecto.Id,
                    StrNombre = proyecto.StrNombre,
                    DtFechaRegistro = proyecto.DtFechaRegistro,
                    IdEmprendedor = proyecto.IdEmprendedor,
                    StrDescripcion = proyecto.StrDescripcion,
                    StrNombreEmpresa = proyecto.StrNombreEmpresa,
                    StrObservaciones = proyecto.StrObservaciones,
                    StrRFC = proyecto.StrRFC,
                    EmprendedorDomainModel = new EmprendedorDomainModel
                    {
                        StrNombre = proyecto.Emprendedores.StrNombre,
                        Id = proyecto.Emprendedores.Id,
                        IdStatus = proyecto.Emprendedores.IdStatus,
                        StrApellidoPaterno = proyecto.Emprendedores.StrApellidoPaterno,
                        StrApellidoMaterno = proyecto.Emprendedores.StrApellidoMaterno,
                        StrCurp = proyecto.Emprendedores.StrCurp,
                        StrEmail = proyecto.Emprendedores.StrEmail,
                        StrFechaNacimiento = proyecto.Emprendedores.StrFechaNacimiento
                    }
                };
                return proyectoDM;
            }
            else {
                return proyectoDM;
            }
        }

        /// <summary>
        /// Este metodo se encarga de eliminar logicamente de la base de datos un proyecto especifico
        /// </summary>
        /// <param name="Id">el identificador del proyecto</param>
        /// <returns>regresa true o false dependiendo de la acción</returns>
        public bool DeleteProyecto(string Id)
        {
            var proyecto = repository.SingleOrDefault(p => p.Id == Id);
            if (proyecto != null)
            {
                proyecto.IdStatus = (int)Enum.StatusEnum.Eliminar;
                repository.Update(proyecto);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Este metodo se encarga de actualizar los datos basicos del proyecto
        /// </summary>
        /// <param name="proyectoDM">la entidad proyecto</param>
        /// <returns>un valor boolean true/false</returns>
        public bool UpdateProyecto(ProyectoDomainModel proyectoDM)
        {
            bool resultado = false;
            if (proyectoDM != null)
            {
                Proyectos proyectos = repository.SingleOrDefault(p => p.Id == proyectoDM.Id);
                if (!string.IsNullOrEmpty(proyectoDM.Id))
                {
                    proyectos.StrNombre = proyectoDM.StrNombre;
                    proyectos.StrNombreEmpresa = proyectoDM.StrNombreEmpresa;
                    proyectos.StrRFC = proyectoDM.StrRFC;
                    proyectos.StrObservaciones = proyectoDM.StrObservaciones;
                    proyectos.Emprendedores.StrNombre = proyectoDM.EmprendedorDomainModel.StrNombre;
                    proyectos.Emprendedores.StrApellidoPaterno = proyectoDM.EmprendedorDomainModel.StrApellidoPaterno;
                    proyectos.Emprendedores.StrApellidoMaterno = proyectoDM.EmprendedorDomainModel.StrApellidoMaterno;
                    repository.Update(proyectos);
                    resultado = true;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Este metodo se encarga de consultar un proyecto por Id
        /// </summary>
        /// <param name="Id">el identificador del proyecto</param>
        /// <returns>regresa la entidad del proyecto</returns>
        public ProyectoDomainModel GetProyectoById(string Id)
        {
            ProyectoDomainModel proyectoDM = new ProyectoDomainModel();
            var proyecto = repository.SingleOrDefault(p => p.Id == Id);
            proyectoDM.Id = proyecto.Id;
            proyectoDM.StrNombre = proyecto.StrNombre;
            proyectoDM.StrDescripcion = proyecto.StrDescripcion;
            proyectoDM.StrNombreEmpresa = proyecto.StrNombreEmpresa;
            proyectoDM.IntConstituidaLegal = proyecto.IntConstituidaLegal;
            proyectoDM.DtFechaRegistro = proyecto.DtFechaRegistro;
            proyectoDM.StrRFC = proyecto.StrRFC;
            proyectoDM.StrObservaciones = proyecto.StrObservaciones;
            proyectoDM.IdEmprendedor = proyecto.IdEmprendedor;
            proyectoDM.IdGiro = proyecto.IdGiro;
            proyectoDM.IdFase = proyecto.IdFase;
            return proyectoDM;

        }
        /// <summary>
        /// Este metodo se encarga de consultar todos los proyectos de la base de datos
        /// </summary>
        /// <returns>retorna una lista de proyectos</returns>
        public List<ProyectoDomainModel> GetProyectos()
        {
            var proyectos = repository.GetAll().Select(p => new ProyectoDomainModel
            {
                Id = p.Id,
                StrNombre = p.StrNombre,
                StrNombreEmpresa = p.StrNombreEmpresa,
                IdGiro = p.IdGiro,
                StrDescripcion = p.StrDescripcion,
                IdFase = p.IdFase,
                IntConstituidaLegal = p.IntConstituidaLegal,
                StrObservaciones = p.StrObservaciones,
                StrRFC = p.StrRFC,
                DtFechaRegistro = p.DtFechaRegistro,
                IdEmprendedor = p.IdEmprendedor
            }).ToList();
            return proyectos;
        }

        public List<ProyectoDomainModel> GetProyectoByIdUser(string Id)
        {

            ProyectoDomainModel proyectoUserID = new ProyectoDomainModel();
            var proyecto = repository.GetIncludeAll(p => p.Status.Id == (int)StatusEnum.Activo, "Emprendedores").ToList();
            var proyectos = proyecto.Where(x => x.Emprendedores.IdUsuario == Id).Select(proy => new ProyectoDomainModel
            {
                Id = proy.Id,
                StrNombre = proy.StrNombre,
                StrNombreEmpresa = proy.StrNombreEmpresa,
                IdGiro = proy.IdGiro,
                StrDescripcion = proy.StrDescripcion,
                IdFase = proy.IdFase,
                IntConstituidaLegal = proy.IntConstituidaLegal,
                StrObservaciones = proy.StrObservaciones,
                StrRFC = proy.StrRFC,
                DtFechaRegistro = proy.DtFechaRegistro,
                IdEmprendedor = proy.IdEmprendedor,
                EmprendedorDomainModel = new EmprendedorDomainModel
                {
                    StrNombre = proy.Emprendedores.StrNombre,
                    Id = proy.Emprendedores.Id,
                    IdStatus = proy.Emprendedores.IdStatus,
                    StrApellidoPaterno = proy.Emprendedores.StrApellidoPaterno,
                    StrApellidoMaterno = proy.Emprendedores.StrApellidoMaterno,
                    StrCurp = proy.Emprendedores.StrCurp,
                    StrEmail = proy.Emprendedores.StrEmail,
                    StrFechaNacimiento = proy.Emprendedores.StrFechaNacimiento
                }
            }).ToList();
            return proyectos;
        }

        #region Se encarga de consultar los poryectos por id parea convertirlos en una lista

        public List<ProyectoDomainModel> GetProyectoByIdNew(string Id)
        {
            var consti = repository.GetAll(p => p.Id == Id).Select(p => new ProyectoDomainModel
            {
                Id = p.Id,
                StrNombre = p.StrNombre,
                StrNombreEmpresa = p.StrNombreEmpresa,
                IdGiro = p.IdGiro,
                StrDescripcion = p.StrDescripcion,
                IdFase = p.IdFase,
                IntConstituidaLegal = p.IntConstituidaLegal,
                StrObservaciones = p.StrObservaciones,
                StrRFC = p.StrRFC,
                DtFechaRegistro = p.DtFechaRegistro,
                IdEmprendedor = p.IdEmprendedor
            }).ToList();

            var proyectos = consti.Select(proy => new ProyectoDomainModel
            {
                Id = proy.Id,
                StrNombre = proy.StrNombre,
                StrNombreEmpresa = proy.StrNombreEmpresa,
                StrDescripcion = proy.StrDescripcion,
                IdEmprendedor = proy.IdEmprendedor,

            }).ToList();
            return proyectos;
        }
        #endregion





       #region Se Encarga de consultar todos los poryectos y regresa cuantos dependiendo su giro para la graficacion

        public List<EstadisticasGiroEmpresarialDM> TotalProyectosGiro()
        {
            ///Tiene que traerme los proyectos contarlos y decirme el giro en el que estan
            List<EstadisticasGiroEmpresarialDM> estadisticas = new List<EstadisticasGiroEmpresarialDM>();

            var giros = giroRepository.GetAll().ToList();
            foreach (var g in giros)
            {
                var proyecto = repository.GetAll().Select(p => new ProyectoDomainModel
                {
                    IdGiro = p.IdGiro
                }).Where(p => p.IdGiro == g.Id).ToList();
                EstadisticasGiroEmpresarialDM estadistica = new EstadisticasGiroEmpresarialDM { Giro = g.StrValor, Total = proyecto.Count() };
                estadisticas.Add(estadistica);
            }

            return estadisticas;
           
        }
        #endregion

        #region Se encarga de contabilizar los proyectos por estatus legales 

        public List<EstatusLegalDM> TotalConstituidos()
        {
            List<EstatusLegalDM> status = new List<EstatusLegalDM>();

            var projectYes = repository.SingleOrDefault(p => p.IntConstituidaLegal == 1);

            var projects = repository.GetAll().Select(p => new ProyectoDomainModel
            {
                IntConstituidaLegal = p.IntConstituidaLegal,
            }).Where(p => p.IntConstituidaLegal == projectYes.IntConstituidaLegal).ToList();
            EstatusLegalDM estatus = new EstatusLegalDM { ConstituidoLegal = projectYes.IntConstituidaLegal, Total = projects.Count() };
            status.Add(estatus);

            var projectNo = repository.SingleOrDefault(p => p.IntConstituidaLegal == 2);

            var projectsNo = repository.GetAll().Select(p => new ProyectoDomainModel
            {
                IntConstituidaLegal = p.IntConstituidaLegal,
            }).Where(p => p.IntConstituidaLegal == projectNo.IntConstituidaLegal).ToList();
            EstatusLegalDM estatus2 = new EstatusLegalDM { ConstituidoLegal = projectNo.IntConstituidaLegal, Total = projectsNo.Count() };
            status.Add(estatus2);

            var projectProcess = repository.SingleOrDefault(p => p.IntConstituidaLegal == 3);

            var projectsProcess = repository.GetAll().Select(p => new ProyectoDomainModel
            {
                IntConstituidaLegal = p.IntConstituidaLegal,
            }).Where(p => p.IntConstituidaLegal == projectProcess.IntConstituidaLegal).ToList();
            EstatusLegalDM estatus3 = new EstatusLegalDM { ConstituidoLegal = projectProcess.IntConstituidaLegal, Total = projectsProcess.Count() };
            status.Add(estatus3);

            //var projectOther = repository.SingleOrDefault(p => p.IntConstituidaLegal == 4);

            //var projectsOther = repository.GetAll().Select(p => new ProyectoDomainModel
            //{
            //    IntConstituidaLegal = p.IntConstituidaLegal,
            //}).Where(p => p.IntConstituidaLegal == projectOther.IntConstituidaLegal).ToList();
            //EstatusLegalDM estatus4 = new EstatusLegalDM { ConstituidoLegal = projectOther.IntConstituidaLegal, Total = projectsOther.Count() };
            //status.Add(estatus4);

            return status;

        }
            

        #endregion



    }
}

