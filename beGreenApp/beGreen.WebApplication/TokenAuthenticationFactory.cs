using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using beGreen.Model.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace beGreen.WebApplication
{
    public static class TokenAuthenticationFactory
    {
        private static string _issuer = string.Empty;
        private static string _audience = string.Empty;
        private static string _base64CertFile = string.Empty;
        private static X509Certificate2 _cert = null;
        private static SecurityKey _securityKeyX509 = null;
        private static SecurityKey _securityKeySymm = null;
        // You can use the SymmetricSecurityKey with SecurityAlgorithms.HmacSha256
        private static SigningCredentials _signingCredential = null;

        private static readonly TokenValidationParameters _tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ClockSkew = TimeSpan.Zero,

            ValidIssuer = _issuer,
            ValidAudience = _audience,
            IssuerSigningKey = _securityKeyX509
        };

        public static void Set(JwtSettings jwtSettings)
        {
            _issuer = jwtSettings.Issuer;
            _audience = jwtSettings.Audience;
            _base64CertFile = jwtSettings.Base64CertFile;
            _cert = new X509Certificate2(Convert.FromBase64String(jwtSettings.Base64CertFile), jwtSettings.Password);
            _securityKeyX509 = new X509SecurityKey(_cert);
            _securityKeySymm = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            _signingCredential = new SigningCredentials(_securityKeySymm, SecurityAlgorithms.RsaSha256);
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services
              .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options => {
                  options.TokenValidationParameters = _tokenValidationParameters;
                  options.Events = new JwtBearerEvents
                  {
                      OnMessageReceived = context => // Retrieve the token from the cookie.
                      {
                          context.Token = context.Request.Cookies["CookieName"];
                          return Task.CompletedTask;
                      }
                  };
              });

            return services;
        }

        public static string CreateToken(IEnumerable<Claim> claims)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _issuer,
                Audience = _audience,
                Expires = DateTime.Now.AddDays(365),
                SigningCredentials = _signingCredential
            };

            SecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static bool TryValidateToken(string token, out ClaimsPrincipal claimsPrincipal)
        {
            SecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var securityToken);

                return true;
            }
            // The exception can be: ArgumentException, SecurityTokenValidationException
            catch (Exception)
            {
                claimsPrincipal = null;

                return false;
            }
        }
    }
}

