using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarritoQuinto.BackEnd.Startup))]
namespace CarritoQuinto.BackEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
