using System;
using System.Collections.Generic;
using System.Text;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;
using beGreen.Model;
using beGreen.Model.Entity;

namespace beGreen.Services
{
    public class DeviceProfileConnectionService : IDeviceProfileConnectionService
    {
        private readonly IDeviceProfileConnectionRepository _deviceProfileConnectionRepository;

        public DeviceProfileConnectionService(IDeviceProfileConnectionRepository deviceProfileConnectionRepository)
        {
            _deviceProfileConnectionRepository = deviceProfileConnectionRepository;
        }

        public ResponseMessage<DeviceProfileConnection> Create(DeviceProfileConnection entity)
        {
            ResponseMessage<DeviceProfileConnection> response = new ResponseMessage<DeviceProfileConnection>();

            try
            {
                response.ResponseObject = _deviceProfileConnectionRepository.Create(entity);
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

        public ResponseMessage DeleteByDevice(string device)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _deviceProfileConnectionRepository.DeleteByDevice(device);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage DeleteByProfile(string profile)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _deviceProfileConnectionRepository.DeleteByProfile(profile);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage<List<DeviceProfileConnection>> GetByDevice(string device)
        {
            ResponseMessage<List<DeviceProfileConnection>> response = new ResponseMessage<List<DeviceProfileConnection>>();

            try
            {
                response.ResponseObject = _deviceProfileConnectionRepository.GetByDevice(device);
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
        public ResponseMessage<List<DeviceProfileConnection>> GetByProfile(string device)
        {
            ResponseMessage<List<DeviceProfileConnection>> response = new ResponseMessage<List<DeviceProfileConnection>>();

            try
            {
                response.ResponseObject = _deviceProfileConnectionRepository.GetByProfile(device);
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
        public ResponseMessage<DeviceProfileConnection> GetByBoth(DeviceProfileConnection device)
        {
            ResponseMessage<DeviceProfileConnection> response = new ResponseMessage<DeviceProfileConnection>();

            try
            {
                response.ResponseObject = _deviceProfileConnectionRepository.GetByBoth(device);
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
        public ResponseMessage<List<DeviceProfileConnection>> GetAll()
        {
            ResponseMessage<List<DeviceProfileConnection>> response = new ResponseMessage<List<DeviceProfileConnection>>();

            try
            {
                response.ResponseObject = _deviceProfileConnectionRepository.GetAll();
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
