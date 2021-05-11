using beGreen.Model.Entity;
using beGreen.Model.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;

namespace beGreen.WebApplication.Authentication.Interfaces
{
    public interface ITokenStoreService
    {
        Task<TokenObject> CreateJwtTokens(User user);
        Task<TokenObject> CreateJwtTokens(string identity, string role = "Visitor");

        Task<ClaimsPrincipal> GetPrincipalFromExpiredTokenAsync(string token);

        TokenValidationParameters TokenValidationParameters();
    }
}
