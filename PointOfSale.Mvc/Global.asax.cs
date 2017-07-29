using PointOfSale.Infrastructure.IoC;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PointOfSale.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(SimpleInjectorConfig.RegisterServices());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
