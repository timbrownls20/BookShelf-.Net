using BookShelf.DataAccess.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web;
using System.Web.Mvc;

namespace BookShelf.MVC.Infrastructure
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var allTypesFromBinDir = Classes.FromAssemblyInDirectory(new AssemblyFilter(HttpRuntime.BinDirectory));

            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());

            container.Register(allTypesFromBinDir
                               .BasedOn<ITransient>()
                               .WithServiceDefaultInterfaces()
                               .LifestyleTransient());
        }
        
    }
}