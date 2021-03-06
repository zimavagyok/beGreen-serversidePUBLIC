using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beGreen.WebApplication.Authentication.Interfaces
{
    public interface ITokenValidatorService
    {
        Task<TokenValidatedContext> ValidateAsync(TokenValidatedContext context);
    }
}
