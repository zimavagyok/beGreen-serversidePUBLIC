using beGreen.Infrastructure.service;
using beGreen.Model;
using beGreen.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beGreen.WebApplication.Controllers
{
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly IDeviceProfileConnectionService _deviceProfileConnectionService;

        public ConnectionController(IDeviceProfileConnectionService deviceProfileConnectionService)
        {
            _deviceProfileConnectionService = deviceProfileConnectionService;
        }
        [HttpPost("api/connectionCreate")]
        public DeviceProfileConnection Create([FromBody] DeviceProfileConnection entity)
        {
            ResponseMessage<DeviceProfileConnection> request = _deviceProfileConnectionService.Create(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
        [HttpPost("api/getConnection")]
        public DeviceProfileConnection GetByBoth([FromBody] DeviceProfileConnection entity)
        {
            ResponseMessage<DeviceProfileConnection> request = _deviceProfileConnectionService.GetByBoth(entity);

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
    }
}
