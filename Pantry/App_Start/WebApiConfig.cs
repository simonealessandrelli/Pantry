﻿using System.Net.Http.Headers;
using System.Web.Http;

namespace Pantry {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Servizi e configurazione dell'API Web

            //Route dell'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //return JSON response by default
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
