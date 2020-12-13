using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inveon.ADMIN.Startup))]
namespace Inveon.ADMIN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
