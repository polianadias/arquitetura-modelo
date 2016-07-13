using System.Web.Http;
using WebActivatorEx;
using ArquiteturaModelo.Servicos.REST.ModeloAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ArquiteturaModelo.Servicos.REST.ModeloAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ArquiteturaModelo.Servicos.REST.ModeloAPI");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\ArquiteturaModelo.Servicos.REST.ModeloAPI.XML",
                        System.AppDomain.CurrentDomain.BaseDirectory));

                    })
                .EnableSwaggerUi(c => {});
        }
    }
}
