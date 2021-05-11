using System;
using System.Collections.Generic;
using beGreen.Services;
using beGreen.Model.Entity;
using beGreen.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using beGreen.Model.Response;
using beGreen.Infrastructure.service;

namespace beGreen.WebApplication.Controllers
{
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }
        [HttpGet("api/getManufacturer/{name}")]
        public Manufacturer GetByID([FromRoute] string name)
        {
            ResponseMessage<Manufacturer> request = _manufacturerService.GetByName(name);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpGet("api/manufacturerers")]
        public List<Manufacturer> GetAll()
        {
            ResponseMessage<List<Manufacturer>> request = _manufacturerService.GetAll();

            if (request == null || !request.IsSuccess || request.ResponseObject == null)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPost("api/manufacturer/create")]
        public Manufacturer Create([FromBody] Manufacturer entity)
        {
            ResponseMessage<Manufacturer> request = _manufacturerService.Create(entity);

            if(!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpPut("api/manufacturerUpdate/update")]
        public Manufacturer Update([FromBody] Manufacturer entity)
        {
            ResponseMessage<Manufacturer> request = _manufacturerService.Update(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpGet("api/manufacturer/{id}")]
        public bool Delete(int id)
        {
            ResponseMessage request = _manufacturerService.Delete(id);

            if(!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.IsSuccess;
        }
    }

}