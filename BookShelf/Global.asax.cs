using BookShelf.DataAccess;
using BookShelf.MVC.Infrastructure;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookShelf.MVC
{
    
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            BootstrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}
