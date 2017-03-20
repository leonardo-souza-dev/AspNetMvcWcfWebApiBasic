using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteLeonardo.UI.Startup))]
namespace TesteLeonardo.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
