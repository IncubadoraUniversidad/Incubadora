using Incubadora.Business;
using Incubadora.Business.Interface;
using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Incubadora
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            
            container.RegisterType<IAspNetRolesBusiness, AspNetRolesBusiness>();
            container.RegisterType<IAspNetUsersBusiness, AspNetUsersBusiness>();
            container.RegisterType<IEmprendedorBusiness, EmprendedorBusiness>();
            container.RegisterType<IEstadoBusiness, EstadoBusiness>();
            container.RegisterType<IMunicipioBusiness, MunicipioBusiness>();
            container.RegisterType<IColoniaBusiness, ColoniaBusiness>();
            container.RegisterType<IUnidadAcademicaBusiness, UnidadAcademicaBusiness>();
            container.RegisterType<ICarreraBusiness, CarreraBusiness>();
            container.RegisterType<ICuatrimestreBusiness, CuatrimestreBusiness>();
            container.RegisterType<IServicioBusiness, ServicioBusiness>();
            container.RegisterType<IGiroBusiness, GiroBusiness>();
            container.RegisterType<IFaseBusiness, FaseBusiness>();
            container.RegisterType<IProyectoBusiness, ProyectoBusiness>();
            container.RegisterType<IStatusBusiness, StatusBusiness>();

            //container.RegisterType<ICalendarizacionBusiness, CalendarizacionBusiness>();
            container.RegisterType<ISubModuloBusiness, SubModulosBusiness>();
            container.RegisterType<ISubModuloSesionesProyectoBusiness, SubModuloSesionesProyectoBusiness>();

            container.RegisterType<IDocenteBusiness, DocenteBusiness>();
            container.RegisterType<IEmailBusiness, EmailBusiness>();
            container.RegisterType<IRecursoBusiness, RecursoBusiness>();

            container.RegisterType<IEstudianteBusiness, EstudianteBusiness>();
            container.RegisterType<IPeriodoEstadiaBusiness, PeriodoEstadiaBusiness>();
            container.RegisterType<IGrupoBusiness, GrupoBusiness>();
            container.RegisterType<IUnidadAcademicaBusiness, UnidadAcademicaBusiness>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}