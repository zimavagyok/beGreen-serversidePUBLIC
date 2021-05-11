using beGreen.Model.Entity;
using beGreen.Model.Identity;
using beGreen.WebApplication.Authentication.Interfaces;
using beGreen.WebApplication.Authentication.Aut_Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace beGreen.WebApplication.Authentication
{
    public class TokenStoreService : ITokenStoreService
    {
        private JwtSettings _jwtOptions;

        public TokenStoreService(JwtSettings jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public async Task<TokenObject> CreateJwtTokens(User user)
        {
            List<Claim> claims = CreateClaims(user);

            return await CreateAccessTokenAsync(claims).ConfigureAwait(false);
        }

        public async Task<TokenObject> CreateJwtTokens(string identity, string role = "Visitor")
        {
            List<Claim> claims = CreateClaims(identity, role);

            return await CreateAccessTokenAsync(claims).ConfigureAwait(false);
        }

        private List<Claim> CreateClaims(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, new string(user.PublicID.Reverse().ToArray())),
                new Claim("Role", user.Role)
            };

            return claims;
        }

        private List<Claim> CreateClaims(string identity, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, new string(identity.Reverse().ToArray())),
                new Claim("Role", role)
            };

            return claims;
        }

        private async Task<TokenObject> CreateAccessTokenAsync(List<Claim> claims)
        {
            //generate token
            SymmetricSecurityKey key = new SymmetricSecurityKey(TokenStoreSecurityService.GetSha256Hash(_jwtOptions.Key));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(5),
                signingCredentials: creds);

            TokenObject tokenObject = new TokenObject
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return await Task.FromResult(tokenObject);
        }

        public TokenValidationParameters TokenValidationParameters()
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = _jwtOptions.Issuer, // site that makes the token
                ValidateIssuer = true, // TODO: change this to avoid forwarding attacks
                ValidAudience = _jwtOptions.Audience, // site that consumes the token
                ValidateAudience = true, // TODO: change this to avoid forwarding attacks
                IssuerSigningKey = new SymmetricSecurityKey(TokenStoreSecurityService.GetSha256Hash(_jwtOptions.Key)),
                ValidateIssuerSigningKey = true, // verify signature to avoid tampering
                ValidateLifetime = true, // validate the expiration
                ClockSkew = TimeSpan.Zero // tolerance for the expiration date
            };

            return tokenValidationParameters;
        }

        public async Task<ClaimsPrincipal> GetPrincipalFromExpiredTokenAsync(string token)
        {
            TokenValidationParameters tokenValidationParameters = TokenValidationParameters();

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return await Task.FromResult(principal);
        }

        /// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        /// <summary>
        /// Generates a random value (nonce) for each generated token.
        /// </summary>
        /// <remarks>The default nonce is a random GUID.</remarks>
        private Func<Task<string>> NonceGenerator { get; set; } = new Func<Task<string>>(() => Task.FromResult(Guid.NewGuid().ToString()));

    }
}

