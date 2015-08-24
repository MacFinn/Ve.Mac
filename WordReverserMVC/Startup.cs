using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordReverserMVC.Startup))]
namespace WordReverserMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
