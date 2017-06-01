using MAutoSS.Web.App_Start;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace MAutoSS.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
