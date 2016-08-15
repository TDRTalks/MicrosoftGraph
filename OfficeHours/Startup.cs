using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OfficeHours.Startup))]

namespace OfficeHours
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // IN App_Start
            ConfigureAuth(app);
        }
    }
}
