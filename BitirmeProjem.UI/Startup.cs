using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BitirmeProjem.UI.Startup))]
namespace BitirmeProjem.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
