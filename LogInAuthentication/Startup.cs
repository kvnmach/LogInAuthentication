using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogInAuthentication.Startup))]
namespace LogInAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
