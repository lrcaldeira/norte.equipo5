using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(norte.equipo5.Startup))]
namespace norte.equipo5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
