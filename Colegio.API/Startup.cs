using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Colegio.BL.Data;

[assembly: OwinStartup(typeof(Colegio.API.Startup))]

namespace Colegio.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ColegioContext.Create);
        }
    }
}
