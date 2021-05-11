using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Response;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;

namespace beGreen.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public ResponseMessage<Device> Create(Device entity)
        {
            ResponseMessage<Device> response = new ResponseMessage<Device>();

            try
            {
                response.ResponseObject = _deviceRepository.Create(entity);
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

        public ResponseMessage<Device> Update(Device entity)
        {
            ResponseMessage<Device> response = new ResponseMessage<Device>();

            try
            {
                response.ResponseObject = _deviceRepository.Update(entity);
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

        public ResponseMessage Delete(string id)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _deviceRepository.Delete(id);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<DeviceResponse> GetByID(string id)
        {
            ResponseMessage<DeviceResponse> response = new ResponseMessage<DeviceResponse>();

            try
            {
                response.ResponseObject = _deviceRepository.GetByID(id);
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

        public ResponseMessage<List<DeviceResponse>> GetAll()
        {
            ResponseMessage<List<DeviceResponse>> response = new ResponseMessage<List<DeviceResponse>>();

            try
            {
                response.ResponseObject = _deviceRepository.GetAll();
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
