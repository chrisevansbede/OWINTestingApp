using Owin;
using System.Web.Http;
using System.Web.Mvc;
using Castle.Windsor;

namespace OWINTestingApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            app.UseWebApi(configuration);
        }
    }
}