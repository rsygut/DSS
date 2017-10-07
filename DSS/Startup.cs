using Microsoft.Owin;
using Owin;
using Repo.Models;

[assembly: OwinStartupAttribute(typeof(DSS.Startup))]
namespace DSS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
