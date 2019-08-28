using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Raw_Vidly_App.Startup))]
namespace Raw_Vidly_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
