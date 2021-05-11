using beGreen.Infrastructure.repository;
using beGreen.Library.Extensions;
using beGreen.Model.Entity;
using beGreen.Model.Enums;
using beGreen.Model.Identity;
using beGreen.WebApplication.Authentication.Interfaces;
using beGreen.WebApplication.Authentication.Aut_Services;
using beGreen.WebApplication.exceptionResponseMiddleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace beGreen.WebApplication.Authentication
{
    public class TokenValidatorService : ITokenValidatorService
    {
        private readonly ITokenStoreService _tokenStoreService;
        private readonly IProfileRepository _profileRepository;
        private readonly IOptions<JwtSettings> _jwtOptions;

        public TokenValidatorService(ITokenStoreService tokenStoreService, IProfileRepository profileRepository, IOptions<JwtSettings> jwtOptions)
        {
            _tokenStoreService = tokenStoreService;
            _profileRepository = profileRepository;
            _jwtOptions = jwtOptions;
        }

        public async Task<TokenValidatedContext> ValidateAsync(TokenValidatedContext context)
        {
            ClaimsPrincipal userPrincipal = context.Principal;

            ClaimsIdentity claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return await Task.FromResult(context);
            }

            string identity = claimsIdentity.FindFirst(ClaimTypes.Name).Value;
            if (string.IsNullOrEmpty(identity))
            {
                context.Fail("This is not our issued token. It has no user identity.");
                return await Task.FromResult(context);
            }

            Profile profile = _profileRepository.GetByID(identity.MakeItOriginal());
            if (profile == null)
            {
                throw new HttpStatusCodeException(HttpResponseType.BadRequest, "Token don't belong to beGreen user!");
            }

            JwtSecurityToken token = context.SecurityToken as JwtSecurityToken;

            DateTime tokenExpiryDate = token.ValidTo;

            if (tokenExpiryDate < DateTime.UtcNow)
            {
                // user has changed his/her password/roles/stat/IsActive
                context.Fail("This token is expired. Please login again.");
                return await Task.FromResult(context);
            }

            if (token == null || string.IsNullOrWhiteSpace(token.RawData))
            {
                context.Fail("This token do not belong to beGreen!");
                return await Task.FromResult(context);
            }

            if (token.Issuer != _jwtOptions.Value.Issuer && token.Audiences.First() != _jwtOptions.Value.Audience)
            {
                throw new HttpStatusCodeException(HttpResponseType.BadRequest, "Token don't belong to beGreen user!");
            }

            TokenValidationParameters tokenValidationParameters = TokenValidationParameters();
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token.RawData, tokenValidationParameters, out securityToken);

            if (securityToken == null || !token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return await Task.FromResult(context);
        }
        public TokenValidationParameters TokenValidationParameters()
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = _jwtOptions.Value.Issuer, // site that makes the token
                ValidateIssuer = true, // TODO: change this to avoid forwarding attacks
                ValidAudience = _jwtOptions.Value.Audience, // site that consumes the token
                ValidateAudience = true, // TODO: change this to avoid forwarding attacks
                IssuerSigningKey = new SymmetricSecurityKey(TokenStoreSecurityService.GetSha256Hash(_jwtOptions.Value.Key)),
                ValidateIssuerSigningKey = true, // verify signature to avoid tampering
                ValidateLifetime = true, // validate the expiration
                ClockSkew = TimeSpan.Zero // tolerance for the expiration date
            };

            return tokenValidationParameters;
        }
    }
}
