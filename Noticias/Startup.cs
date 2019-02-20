using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Noticias.Startup))]
namespace Noticias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
