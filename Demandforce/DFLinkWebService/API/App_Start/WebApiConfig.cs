using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Demandforce.DFLinkServer.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
