using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HESProgram.Startup))]
namespace HESProgram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
