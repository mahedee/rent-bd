using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentBD.Startup))]
namespace RentBD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
