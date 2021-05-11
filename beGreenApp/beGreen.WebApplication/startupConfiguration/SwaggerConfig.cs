using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace beGreen.WebApplication
{
    public static class SwaggerConfig
    {
        public static void ConfigureSWAGGER(this IServiceCollection serviceColletion)
        {
            if (serviceColletion == null)
            {
                throw new ArgumentNullException(nameof(serviceColletion));
            }

            // Use http://localhost:5000/swagger/ui/index to inspect API docs
            serviceColletion.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(Constatns.BackofficeSwaggerGroup, new OpenApiInfo { Title = "Portal Nekretnine - Backoffice", Version = Constatns.BackofficeSwaggerGroup });
                x.SwaggerDoc(Constatns.PublicSwaggerGroup, new OpenApiInfo { Title = "Portal Nekretnine - Public", Version = Constatns.PublicSwaggerGroup });

                // This code allow you to use XML-comments
                string  xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    x.IncludeXmlComments(xmlPath);
                }

                x.AddSecurityDefinition
                (
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter token into the field",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    }
                );
            });
        }

        public static void UseSWAGGER(this IApplicationBuilder applicationBuilder)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            applicationBuilder.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            applicationBuilder.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint($"/swagger/{Constatns.BackofficeSwaggerGroup}/swagger.json", "Portal Nekretnine - Backoffice");
                x.SwaggerEndpoint($"/swagger/{Constatns.PublicSwaggerGroup}/swagger.json", "Portal Nekretnine - Public");
            });
        }
    }
}

