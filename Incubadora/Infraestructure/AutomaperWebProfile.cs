using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.ViewModels;
using System.Collections.Generic;

namespace Incubadora.Infraestructure
{
    public class AutomaperWebProfile : AutoMapper.Profile
    {
        public AutomaperWebProfile()
        {
            //entidad AspNetRoles
            CreateMap<AspNetRolesDomainModel, AspNetRolesVM>();
            CreateMap<AspNetRolesVM, AspNetRolesDomainModel>();

            //entidad AspNetUsers
            CreateMap<AspNetUsersDomainModel, AspNetUsersVM>().ForMember(x=>x.AspNetRolesVM, x=>x.MapFrom(p=>p.AspNetRolesDomainModel));
            CreateMap<AspNetUsersVM, AspNetUsersDomainModel>().ForMember(x=>x.AspNetRolesDomainModel, x=>x.MapFrom(p=>p.AspNetRolesVM));

            // Entidad Carreras
            CreateMap<CarreraDomainModel, CarreraVM>();
            CreateMap<CarreraVM, CarreraDomainModel>();

            //Entidad Status
            CreateMap<StatusDomainModel, StatusVM>();
            CreateMap<StatusVM, StatusDomainModel>();

            // Entidad Colonias
            CreateMap<ColoniaDomainModel, ColoniaVM>();
            CreateMap<ColoniaVM, ColoniaDomainModel>();

            // Entidad Cuatrimestres
            CreateMap<CuatrimestreDomainModel, CuatrimestreVM>();
            CreateMap<CuatrimestreVM, CuatrimestreDomainModel>();

            // Entidad DatosLaborales
            CreateMap<DatoLaboralDomainModel, DatoLaboralVM>();
            CreateMap<DatoLaboralVM, DatoLaboralDomainModel>();

            // Entidad Direcciones
            CreateMap<DireccionDomainModel, DireccionVM>();
            CreateMap<DireccionVM, DireccionDomainModel>();

            // Entidad Emprendedores
            CreateMap<EmprendedorDomainModel, EmprendedorVM>()
                .ForMember(x => x.DatoLaboralVM, x => x.MapFrom(p => p.DatoLaboralDomainModel))
                .ForMember(x => x.DireccionVM, x => x.MapFrom(p => p.DireccionDomainModel))
                .ForMember(x => x.TelefonoVM, x => x.MapFrom(p => p.TelefonoDomainModel))
                .ForMember(x => x.AspNetUserVM, x => x.MapFrom(p => p.AspNetUserDomainModel));
            CreateMap<EmprendedorVM, EmprendedorDomainModel>()
                .ForMember(x => x.DatoLaboralDomainModel, x => x.MapFrom(p => p.DatoLaboralVM))
                .ForMember(x => x.DireccionDomainModel, x => x.MapFrom(p => p.DireccionVM))
                .ForMember(x => x.TelefonoDomainModel, x => x.MapFrom(p => p.TelefonoVM))
                .ForMember(x => x.AspNetUserDomainModel, x => x.MapFrom(p => p.AspNetUserVM));

            // Clase Login, ya que esta no está representada como tal en la base de datos ni en las entities generadas por EF.
            CreateMap<LoginDomainModel, LoginVM>();
            CreateMap<LoginVM, LoginDomainModel>();

            // Entidad Municipios
            CreateMap<MunicipioDomainModel, MunicipioVM>();
            CreateMap<MunicipioVM, MunicipioDomainModel>();

            // Entidad Telefonos
            CreateMap<TelefonoDomainModel, TelefonoVM>();
            CreateMap<TelefonoVM, TelefonoDomainModel>();

            // Entidad UnidadesAcademicas
            CreateMap<UnidadAcademicaDomainModel, UnidadAcademicaVM>();
            CreateMap<UnidadAcademicaVM, UnidadAcademicaDomainModel>();

            // Entidad ServiciosUniversitarios
            CreateMap<ServicioUniversitarioDomainModel, ServicioUniversitarioVM>();
            CreateMap<ServicioUniversitarioVM, ServicioUniversitarioDomainModel>();

            // Entidad RecursosProyectos
            CreateMap<RecursoProyectDomainModel, RecursoProyectoVM>();
            CreateMap<RecursoProyectoVM, RecursoProyectDomainModel>();

            // Entidad Proyectos
            CreateMap<ProyectoDomainModel, ProyectoVM>()
                .ForMember(x=> x.EmprendedorVM, x=> x.MapFrom(p=>p.EmprendedorDomainModel))
                .ForMember(x => x.RecursosProyectosVM, x => x.MapFrom(MapProyectoRecursosToDM))
                .ForMember(x => x.ServiciosUniversitariosVM, x => x.MapFrom(MapProyectoServUnivToDM));
            CreateMap<ProyectoVM, ProyectoDomainModel>()
                .ForMember(x=>x.EmprendedorDomainModel, x=>x.MapFrom(p=>p.EmprendedorVM))
                .ForMember(x => x.RecursosProyectosDomainModel, x => x.MapFrom(MapProyectoRecursosToVM))
                .ForMember(x => x.ServiciosUniversitariosDomainModel, x => x.MapFrom(MapProyectoServUnivToVM));
            // Entidad Docentes
            CreateMap<DocenteDomainModel, DocenteVM>()
                .ForMember(x => x.AspNetUserVM, x => x.MapFrom(d => d.AspNetUserDomainModel));
            CreateMap<DocenteVM, DocenteDomainModel>()
                .ForMember(x => x.AspNetUserDomainModel, x => x.MapFrom(d => d.AspNetUserVM));
            CreateMap<SubModuloSesionesProyectoVM, SubModuloSesionesProyectoDomainModel>();
            CreateMap<SubModuloSesionesProyectoDomainModel, SubModuloSesionesProyectoVM>();
        }
        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperWebProfile>();
            });
        }

        private List<RecursoProyectDomainModel> MapProyectoRecursosToDM(ProyectoDomainModel proyectoDM, ProyectoVM proyectoVM)
        {
            var resultado = new List<RecursoProyectDomainModel>();
            if (proyectoDM.RecursosProyectosDomainModel == null)
            {
                return resultado;
            }
            foreach (var recursoProyecto in proyectoDM.RecursosProyectosDomainModel)
            {
                resultado.Add(new RecursoProyectDomainModel()
                {
                    Id = recursoProyecto.Id,
                    IdProyecto = recursoProyecto.IdProyecto,
                   IdRecurso= recursoProyecto.IdRecurso,
                   
                });
            }
            return resultado;
        }

        private List<RecursoProyectoVM> MapProyectoRecursosToVM(ProyectoVM proyectoVM, ProyectoDomainModel proyectoDM)
        {
            var resultado = new List<RecursoProyectoVM>();
            if (proyectoVM.RecursosProyectosVM == null)
            {
                return resultado;
            }
            foreach (var recursoProyecto in proyectoVM.RecursosProyectosVM)
            {
                resultado.Add(new RecursoProyectoVM()
                {
                    Id = recursoProyecto.Id,
                    IdProyecto = recursoProyecto.IdProyecto,
                    IdRecurso = recursoProyecto.IdRecurso,
                });
            }
            return resultado;
        }

        private List<ServicioUniversitarioDomainModel> MapProyectoServUnivToDM(ProyectoDomainModel proyectoDM, ProyectoVM proyectoVM)
        {
            var resultado = new List<ServicioUniversitarioDomainModel>();
            if (proyectoDM.ServiciosUniversitariosDomainModel == null)
            {
                return resultado;
            }
            foreach (var servicioUniversitario in proyectoDM.ServiciosUniversitariosDomainModel)
            {
                resultado.Add(new ServicioUniversitarioDomainModel()
                {
                    Id = servicioUniversitario.Id,
                    IdProyecto = servicioUniversitario.IdProyecto,
                    IdServicio = servicioUniversitario.IdServicio
                });
            }
            return resultado;
        }

        private List<ServicioUniversitarioVM> MapProyectoServUnivToVM(ProyectoVM proyectoVM, ProyectoDomainModel proyectoDM)
        {
            var resultado = new List<ServicioUniversitarioVM>();
            if (proyectoVM.ServiciosUniversitariosVM == null)
            {
                return resultado;
            }
            foreach (var servicioUniversitario in proyectoVM.ServiciosUniversitariosVM)
            {
                resultado.Add(new ServicioUniversitarioVM()
                {
                    Id = servicioUniversitario.Id,
                    IdProyecto = servicioUniversitario.IdProyecto,
                    IdServicio = servicioUniversitario.IdServicio
                });
            }
            return resultado;
        }
    }
}