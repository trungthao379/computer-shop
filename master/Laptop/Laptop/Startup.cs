using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laptop.Startup))]
namespace Laptop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
