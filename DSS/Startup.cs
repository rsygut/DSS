using Microsoft.Owin;
using Owin;

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
