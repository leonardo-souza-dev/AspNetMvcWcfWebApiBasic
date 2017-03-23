using Owin;
using TesteLeonardo.Repositorio;

namespace TesteLeonardo.UI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
        }
    }
}