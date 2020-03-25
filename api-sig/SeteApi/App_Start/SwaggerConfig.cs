using System.Web.Http;
using WebActivatorEx;
using SeteWebApi;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Collections.Generic;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace SeteWebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "API Sistema de Información Geográfica");
                    c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                })
                .EnableSwaggerUi();
        }
 
        /// <summary>
        /// 
        /// </summary>
        public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="operation"></param>
            /// <param name="schemaRegistry"></param>
            /// <param name="apiDescription"></param>
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
              
            }
        }
    }
}