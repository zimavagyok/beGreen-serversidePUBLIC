using beGreen.Library.Attributes.JsonAttribute;
using beGreen.WebApplication.Attributes;
using beGreen.WebApplication.exceptionResponseMiddleware;
using beGreen.WebApplication.extensions;
using beGreen.WebApplication.handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace beGreen.WebApplication
{
    public partial class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder()
                                                                    .SetBasePath(env.ContentRootPath)
                                                                    .AddJsonFile($"appsettings.json", optional: true)
                                                                    .AddEnvironmentVariables();

            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection servicesCollection)
        {
            SetServices(servicesCollection);

            servicesCollection.AddMvc(options =>
                                              options.Filters.Add(typeof(ValidateModelAttribute)))
                            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                           .AddNewtonsoftJson(o => o.SerializerSettings.Converters.Add(new JsonDateConverter()));

            servicesCollection.AddControllers()
                            .AddNewtonsoftJson();

            servicesCollection.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // Add custom binder provider for mapping json object form multipart/form-data
            servicesCollection.AddMvc(properties =>
            {
                properties.ModelBinderProviders.Insert(0, new JsonModelBinderProvider());
            });

            servicesCollection.ConfigureCookieAuthentication();
            servicesCollection.ConfigureAUTH(Configuration);

            servicesCollection.ConfigureCORS();
            servicesCollection.ConfigureSWAGGER();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseAUTH();
            app.UseAuthorization();

            app.UseCORS();
            app.UseSWAGGER();

            app.UseHttpStatusCodeExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
