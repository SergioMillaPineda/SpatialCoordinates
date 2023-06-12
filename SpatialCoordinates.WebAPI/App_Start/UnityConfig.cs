using SpatialCoordinates.Domain.RepositoryContracts;
using SpatialCoordinates.Domain.ServiceContracts;
using SpatialCoordinates.Domain.ServiceImplementations;
using SpatialCoordinates.Infrastructure.Data.RepositoryImplementations;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace SpatialCoordinates.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICoordinatesService, CoordinatesService>();
            container.RegisterType<ICoordinatesRepository, CoordinatesRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}