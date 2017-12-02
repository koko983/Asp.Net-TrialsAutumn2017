using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewIdentityOutlook.Startup))]
namespace NewIdentityOutlook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
