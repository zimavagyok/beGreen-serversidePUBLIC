using System;
using System.Collections.Generic;
using System.Linq;
using beGreen.Services;
using beGreen.Model;
using Microsoft.AspNetCore.Mvc;
using beGreen.Model.Entity;
using Swashbuckle.Swagger.Annotations;
using beGreen.Model.Request;
using beGreen.Infrastructure.service;
using Microsoft.AspNetCore.Authorization;

namespace beGreen.WebApplication.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;

        public UserController(IUserService userService, IProfileService profileService)
        {
            _userService = userService;
            _profileService = profileService;
        }

        [HttpGet("api/user/deactivate/{PublicID}")]
        public bool Deactivate(string PublicID)
        {
            ResponseMessage request = _userService.Deactivate(PublicID);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.IsSuccess;
        }

        [HttpGet("api/users")]
        public List<User> GetAll()
        {
            ResponseMessage<List<User>> request = _userService.GetAll();

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
        [HttpGet("api/getuser")]
        [Authorize]
        public User GetbyID()
        {
            ResponseMessage<User> request = _userService.GetByID(User.Identity.Name);

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPost("api/user")]
        [SwaggerOperation(OperationId = "registerUser")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public User Create([FromBody] RegisterUserRequest data)
        {
            ResponseMessage<User> request = _userService.Create(data);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPut("api/user")]
        [Authorize]
        public User Update([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            changePasswordRequest.PublicID = User.Identity.Name;
            ResponseMessage<User> request = _userService.Update(changePasswordRequest);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpGet("api/user/{id}")]
        public bool Delete(int id)
        {
            ResponseMessage request = _userService.Delete(id);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.IsSuccess;
        }

        [HttpPost("api/findemail")]
        public bool FindEmail([FromBody] string email)
        {
            ResponseMessage<bool> request = _userService.FindEmail(email);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
        [HttpPost("api/matchPassword")]
        [Authorize]
        public bool MatchPassword([FromBody] string password)
        {
            ResponseMessage<bool> request = _userService.MatchPassword(password,User.Identity.Name);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
    }

}