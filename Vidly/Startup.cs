using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Vidly.Startup))]
namespace Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}