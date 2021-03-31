using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HypeTracker.WebMVC.Startup))]
namespace HypeTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
