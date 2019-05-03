using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Esibayeni.Startup))]
namespace Esibayeni
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
