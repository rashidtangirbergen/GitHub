using System.Globalization;
using System.Threading;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Samruk.Web.Startup))]
namespace Samruk.Web {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            ConfigureAuth(app);
        }
    }
}
