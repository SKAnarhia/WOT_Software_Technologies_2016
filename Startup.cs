using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoBlogWasteOfTimeTeam.Startup))]
namespace DemoBlogWasteOfTimeTeam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
