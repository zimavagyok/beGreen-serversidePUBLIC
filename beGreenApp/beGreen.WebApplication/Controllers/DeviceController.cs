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

namespace beGreen.WebApplication.Controllers
{
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IManufacturerService _manufacturerService;

        public DeviceController(IDeviceService deviceService, IManufacturerService manufacturerService)
        {
            _deviceService = deviceService;
            _manufacturerService = manufacturerService;
        }
        [HttpPost("api/getDevice")]
        public DeviceResponse GetByID([FromBody] string uuid )
        {
            ResponseMessage<DeviceResponse> request = _deviceService.GetByID(uuid);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpGet("api/Devices")]
        public List<DeviceResponse> GetAll()
        {
            ResponseMessage<List<DeviceResponse>> request = _deviceService.GetAll();

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPost("api/DeviceCreate")]
        public Device Create([FromBody] Device entity)
        {
            ResponseMessage<Device> request = _deviceService.Create(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPut("api/Device")]
        public Device Update([FromBody] Device entity)
        {
            ResponseMessage<Device> request = _deviceService.Update(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpGet("api/Device/{id}")]
        public bool Delete(string id)
        {
            ResponseMessage request = _deviceService.Delete(id);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.IsSuccess;
        }

    }

}