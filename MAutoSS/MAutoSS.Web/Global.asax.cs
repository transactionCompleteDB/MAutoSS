using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

using MAutoSS.Web.App_Start.DbConfigs;

namespace MAutoSS.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            SqlDbConfig.Initialize();
            PostgreDbConfig.Initialize();
            // SQLiteDbConfig.Initialize();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
