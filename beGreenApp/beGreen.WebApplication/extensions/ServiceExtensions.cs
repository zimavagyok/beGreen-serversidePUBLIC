using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace beGreen.WebApplication.extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCookieAuthentication(this IServiceCollection services)
        {
            services.Configure<CookieAuthenticationOptions>(options =>
            {
                options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                        {
                            ctx.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            return Task.FromResult<object>(null);
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                            return Task.FromResult<object>(null);
                        }
                    }
                };
            });
        }
    }
}
