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

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}