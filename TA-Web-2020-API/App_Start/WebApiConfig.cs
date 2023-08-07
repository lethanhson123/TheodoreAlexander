using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using TA_Web_2020_API.CustomHandler;

namespace TA_Web_2020_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*", "Token, UserInfo");
            config.EnableCors(cors);
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //Exception handler
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "public/api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
                name: "ProtectedApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Custom message handler
            try
            {
                config.MessageHandlers.Add(new CrossDomainHandler());
                //config.MessageHandlers.Add(new IpAddresshandler());
                config.MessageHandlers.Add(new ApiKeyHandler());
                config.MessageHandlers.Add(new TokenHandler());
            }
            catch (Exception ex) {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(ex.Message +" : "+ ex.StackTrace, EventLogEntryType.Error, 1325);
                }
            }
        }
    }
}
