using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;

namespace beGreen.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public ResponseMessage<Manufacturer> Create(Manufacturer entity)
        {
            ResponseMessage<Manufacturer> response = new ResponseMessage<Manufacturer>();

            try
            {
                response.ResponseObject = _manufacturerRepository.Create(entity);
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<Manufacturer> Update(Manufacturer entity)
        {
            ResponseMessage<Manufacturer> response = new ResponseMessage<Manufacturer>();

            try
            {
                response.ResponseObject = _manufacturerRepository.Update(entity);
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _manufacturerRepository.Delete(id);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<Manufacturer> GetByID(int id)
        {
            ResponseMessage<Manufacturer> response = new ResponseMessage<Manufacturer>();

            try
            {
                response.ResponseObject = _manufacturerRepository.GetByID(id);
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage<Manufacturer> GetByName(string name)
        {
            ResponseMessage<Manufacturer> response = new ResponseMessage<Manufacturer>();

            try
            {
                response.ResponseObject = _manufacturerRepository.GetByName(name);
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<List<Manufacturer>> GetAll()
        {
            ResponseMessage<List<Manufacturer>> response = new ResponseMessage<List<Manufacturer>>();

            try
            {
                response.ResponseObject = _manufacturerRepository.GetAll();
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


    }



}
