using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMvcDemoApp.Startup))]
namespace MyMvcDemoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
