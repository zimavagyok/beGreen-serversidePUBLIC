using System;
using System.Collections.Generic;
using beGreen.Services;
using beGreen.Model.Entity;
using beGreen.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using beGreen.Model.Response;
using beGreen.Infrastructure.service;
using beGreen.Model.Request;
using Microsoft.AspNetCore.Authorization;

namespace beGreen.WebApplication.Controllers
{
    [ApiController]
    public class RecyclingBankController : ControllerBase
    {
        private readonly IRecyclingBankService _recyclingBankService;

        public RecyclingBankController(IRecyclingBankService recyclingBankService)
        {
            _recyclingBankService = recyclingBankService;
        }
        [HttpPost("api/createRecyclingBank")]
        [Authorize]
        public RecyclingBank Create([FromBody] RecyclingBankCreateRequest entity)
        {
            ResponseMessage<RecyclingBank> request = _recyclingBankService.Create(entity,User.Identity.Name);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpGet("api/recyclingBank")]
        public List<RecyclingBank> GetAll()
        {
            ResponseMessage<List<RecyclingBank>> request = _recyclingBankService.GetAll();

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPost("api/getallclose")]
        [ProducesResponseType(typeof(List<RecyclingBank>), 200)]
        public List<RecyclingBank> GetAllClose([FromBody] RecyclingBankRequest recyclingBankRequest)
        {
            ResponseMessage<List<RecyclingBank>> request = _recyclingBankService.GetAllClose(recyclingBankRequest);

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
        [HttpGet("api/recyclingBank/{location}")]
        public bool Delete(string location)
        {
            ResponseMessage request = _recyclingBankService.Delete(location);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.IsSuccess;
        }
        [HttpGet("api/getrecyclingbank/{location}")]
        public int GetByLocation([FromRoute] string location)
        {
            ResponseMessage<int> request = _recyclingBankService.GetByLocation(location);

            if (request == null || !request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
    }
}
