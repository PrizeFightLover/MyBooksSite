using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBooksSite.Startup))]
namespace MyBooksSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
