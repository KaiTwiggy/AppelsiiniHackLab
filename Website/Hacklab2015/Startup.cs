using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hacklab2015.Startup))]
namespace Hacklab2015
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
