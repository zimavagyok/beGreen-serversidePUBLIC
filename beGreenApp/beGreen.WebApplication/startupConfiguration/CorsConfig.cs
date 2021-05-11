using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace beGreen.WebApplication
{
    public static class CorsConfig
    {
        public static void ConfigureCORS(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy("Debug", builder =>
                {
                    builder.WithOrigins()
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                });
            });
        }

        public static void UseCORS(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors("Debug");
        }
    }
}
