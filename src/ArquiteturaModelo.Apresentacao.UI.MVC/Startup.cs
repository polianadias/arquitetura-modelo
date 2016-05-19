using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArquiteturaModelo.Apresentacao.UI.MVC.Startup))]
namespace ArquiteturaModelo.Apresentacao.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
