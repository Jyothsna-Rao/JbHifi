using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestFulCrudDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //  config.Routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            //   config.Filters.Add(new AuthorizeAttribute());


            //config.Routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
            //config.Routes.MapHttpRoute(
            //   name: "DefaultApi",
            //   routeTemplate: "api/{controller}/{action}/{id}",
            //   defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
    name: "FilterProducts",
    routeTemplate: "api/Products/GetProducts/{param1}/{param2}/{param3}",
    
    defaults: new
    {
        param1 = RouteParameter.Optional,
        param2 = RouteParameter.Optional,
        param3 = RouteParameter.Optional
    }
);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
