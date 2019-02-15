using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KhMedium.Startup))]
namespace KhMedium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
