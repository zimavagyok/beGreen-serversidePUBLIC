using beGreen.Model.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace beGreen.WebApplication.Attributes
{
    public class RoleAuthorizationAttribute : ActionFilterAttribute
    {
        private string _role;
        private JwtSettings _jwtOptions;

        public RoleAuthorizationAttribute(string role)
        {
            _role = role.ToLower();
            _jwtOptions = GetJwtSettings();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
            }

            string jwt = context.HttpContext.Request.Headers["Bearer"];

            if (string.IsNullOrEmpty(jwt))
            {
                context.Result = new UnauthorizedResult();
            }

            ClaimsPrincipal claimsPrincipal = ValidateToken(jwt);

            if (claimsPrincipal == null)
            {
                context.Result = new UnauthorizedResult();
            }

            string claimRoleData = claimsPrincipal.FindFirst("role")?.Value.ToLower();

            if (claimRoleData.Contains(";"))
            {
                List<string> roles = claimRoleData.Split(';').ToList();

                if (string.IsNullOrEmpty(claimRoleData) || !roles.Contains(_role))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(claimRoleData) || claimRoleData != _role)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }

        private ClaimsPrincipal ValidateToken(string token)
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = _jwtOptions.Issuer, // site that makes the token
                ValidateIssuer = true, // TODO: change this to avoid forwarding attacks
                ValidAudience = _jwtOptions.Audience, // site that consumes the token
                ValidateAudience = true, // TODO: change this to avoid forwarding attacks
                IssuerSigningKey = new SymmetricSecurityKey(GetSha256Hash(_jwtOptions.Key)),
                ValidateIssuerSigningKey = true, // verify signature to avoid tampering
                ValidateLifetime = true, // validate the expiration
                ClockSkew = TimeSpan.Zero // tolerance for the expiration date
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principal;
        }

        private byte[] GetSha256Hash(string input)
        {
            using (SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                byte[] byteValue = Encoding.UTF8.GetBytes(input);
                return hashAlgorithm.ComputeHash(byteValue);
            }
        }

        private JwtSettings GetJwtSettings()
        {
            IConfiguration Configuration;
            JwtSettings jwtOptions = null;

#if DEBUG
            IConfigurationBuilder builder = new ConfigurationBuilder()
                                                                            .AddJsonFile($"appsettings.development.json", optional: true)
                                                                            .AddEnvironmentVariables();

            Configuration = builder.Build();
#else
                IConfigurationBuilder builder = new ConfigurationBuilder()
                                                                              .AddJsonFile($"/var/www/portalnekretnine/appsettings.production.json", optional: true)
                                                                             .AddEnvironmentVariables();

                Configuration = builder.Build();
#endif

            jwtOptions = Configuration.GetValue<JwtSettings>("JwtSettings");

            return jwtOptions;
        }
    }
}
