using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DealersPortal.Startup))]
namespace DealersPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
