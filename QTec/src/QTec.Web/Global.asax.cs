using System.Web.Mvc;
using System.Web.Routing;

namespace QTec.Web
{
    using System.Web.Optimization;

    using QTec.Business;
    using QTec.Web.App_Start;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterMappings();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
