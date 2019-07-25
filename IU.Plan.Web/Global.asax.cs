using IU.Plan.Web.Bindings;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IU.Plan.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ValueProviderFactories.Factories.Add(new BrowserValueProviderFactory());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}