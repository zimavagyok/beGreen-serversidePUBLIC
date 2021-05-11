using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using beGreen.Services;
using beGreen.Model.Entity;
using beGreen.Model;
using beGreen.Model.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using beGreen.Infrastructure.service;
using Microsoft.AspNetCore.Authorization;
using beGreen.Model.Request;

namespace beGreen.WebApplication.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("api/profiles")]
        public List<ProfileResponse> GetAll()
        {
            ResponseMessage<List<ProfileResponse>> request = _profileService.GetAll();

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPut("api/profile")]
        public Profile Update([FromBody] Profile entity)
        {
            ResponseMessage<Profile> request = _profileService.Update(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPut("api/namechange")]
        [Authorize]
        public Profile NameChange([FromBody] ChangeNameRequest entity)
        {
            entity.PublicID = User.Identity.Name;
            ResponseMessage<Profile> request = _profileService.ChangeName(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpGet("api/profile/{id}")]
        public bool Delete(int id)
        {
            ResponseMessage request = _profileService.Delete(id);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.IsSuccess;
        }

        [HttpGet("api/getprofile")]
        [Authorize]
        public Profile GetByID()
        {
            ResponseMessage<ProfileResponse> request = _profileService.GetByID(User.Identity.Name);

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
        [HttpPost("api/findusername")]
        public bool FindUsername([FromBody] string username)
        {
            ResponseMessage<bool> request = _profileService.FindUsername(username);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
    }

}