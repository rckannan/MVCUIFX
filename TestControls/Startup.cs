using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestControls.Startup))]
namespace TestControls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
