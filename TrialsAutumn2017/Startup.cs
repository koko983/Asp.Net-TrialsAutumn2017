using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrialsAutumn2017.Startup))]
namespace TrialsAutumn2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
