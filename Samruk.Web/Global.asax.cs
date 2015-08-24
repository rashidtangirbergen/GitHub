using System.Data.Entity;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Samruk.Web.Models;

namespace Samruk.Web {
    public class MvcApplication : HttpApplication {
        protected void Application_Start() {
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            const string culture = "ru-RU";
            CultureInfo ci = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}
