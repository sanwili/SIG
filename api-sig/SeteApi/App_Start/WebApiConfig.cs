using System.Web.Http;

namespace SeteWebApi
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Configuración de rutas y servicios de API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "SIG_API/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
