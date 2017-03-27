using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebIncidencias_UF3.Startup))]
namespace WebIncidencias_UF3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
