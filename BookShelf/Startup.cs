using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookShelf.Startup))]
namespace BookShelf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
