using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.ViewModels;

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
                .ForMember(x => x.TelefonoVM, x => x.MapFrom(p => p.TelefonoDomainModel));
            CreateMap<EmprendedorVM, EmprendedorDomainModel>()
                .ForMember(x => x.DatoLaboralDomainModel, x => x.MapFrom(p => p.DatoLaboralVM))
                .ForMember(x => x.DireccionDomainModel, x => x.MapFrom(p => p.DireccionVM))
                .ForMember(x => x.TelefonoDomainModel, x => x.MapFrom(p => p.TelefonoVM));

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
        }
        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperWebProfile>();
            });
        }
    }
}