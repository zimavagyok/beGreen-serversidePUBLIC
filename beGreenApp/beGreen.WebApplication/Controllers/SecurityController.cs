using Swashbuckle.Swagger;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using beGreen.Infrastructure.service;
using beGreen.WebApplication.Authentication.Interfaces;
using Swashbuckle.Swagger.Annotations;
using beGreen.WebApplication.Attributes;
using beGreen.Model.Enums;
using beGreen.Model.Identity;
using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Request;
using beGreen.WebApplication.exceptionResponseMiddleware;

namespace beGreen.WebApplication.Controllers
{
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IAuditService _loginDeviceAuditService;
        private readonly ITokenStoreService _tokenStoreService;
        private readonly IResetPasswordService _resetPasswordService;
        private readonly IDeviceProfileConnectionService _deviceProfileConnectionService;
        private readonly IDeviceService _deviceService;
        private readonly IManufacturerService _manufacturerService;

        public SecurityController(ISecurityService securityService,
                                                          IAuditService loginDeviceAuditService,
                                                          ITokenStoreService tokenStoreService,
                                                          IResetPasswordService resetPasswordService,
                                                          IDeviceProfileConnectionService deviceProfileConnectionService,
                                                          IDeviceService deviceService,
                                                          IManufacturerService manufacturerService)
        {
            _securityService = securityService;
            _loginDeviceAuditService = loginDeviceAuditService;
            _tokenStoreService = tokenStoreService;
            _resetPasswordService = resetPasswordService;
            _deviceProfileConnectionService = deviceProfileConnectionService;
            _deviceService = deviceService;
            _manufacturerService = manufacturerService;
        }

        /// <summary>
        /// Register visitor
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = Constatns.PublicSwaggerGroup)]
        [SwaggerOperation(OperationId = "registerVisitor")]
        [HttpPost("api/register")]
        [ValidateModel]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(TokenResponse))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public async Task<TokenResponse> RegisterVisitor([FromBody] RegisterUserRequest data)
        {
            //TODO: Telefon hozzárendelése a felhasználóhoz
            ResponseMessage<User> request = _securityService.Create(data);

            if (!request.IsSuccess)
            {
                throw new HttpStatusCodeException(HttpResponseType.BadRequest, request.ErrorMessage);
            }

            TokenObject tokenObject = await _tokenStoreService.CreateJwtTokens(request.ResponseObject).ConfigureAwait(false);

            TokenResponse token = new TokenResponse
            {

                access_token = tokenObject.Token,
                expires_in = TimeSpan.FromDays(5).TotalSeconds
            };

            return token;
        }

        [ApiExplorerSettings(GroupName = Constatns.PublicSwaggerGroup)]
        [SwaggerOperation(OperationId = "login")]
        [HttpPost("api/login")]
        [ValidateModel]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(TokenResponse))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]

        public async Task<TokenResponse> Login([FromBody]LoginRequest loginModel)
        {
            ResponseMessage<User> request = _securityService.FindByCredencials(loginModel.Email, loginModel.Password);

            if (!request.IsSuccess)
            {
                throw new HttpStatusCodeException(HttpResponseType.BadRequest, request.ErrorMessage);
            }
            else if (request.IsSuccess && request.ResponseObject == null)
            {
                throw new HttpStatusCodeException(HttpResponseType.Unauthorized, "Unauthorized");
            }
            else if (request.ResponseObject.Deactivated)
            {
                throw new HttpStatusCodeException(HttpResponseType.Unauthorized, "Deactivated!");
            }

            TokenObject tokenObject = await _tokenStoreService.CreateJwtTokens(request.ResponseObject).ConfigureAwait(false);

            TokenResponse token = new TokenResponse
            {

                access_token = tokenObject.Token,
                expires_in = TimeSpan.FromDays(5).TotalSeconds
            };

            return token;
        }
    }
}
