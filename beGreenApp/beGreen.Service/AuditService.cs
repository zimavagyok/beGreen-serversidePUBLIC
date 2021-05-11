using System;
using System.Collections.Generic;
using System.Text;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;
using beGreen.Library.Extensions;
using beGreen.Model;
using beGreen.Model.Entity;

namespace beGreen.Services
{
    public class AuditService : IAuditService
    {
        private readonly IAuditRepository _loginDeviceHistoryRepository;
        private readonly IUserRepository _userRepository;

        public AuditService(IAuditRepository loginDeviceHistoryRepository,IUserRepository userRepository)
        {
            _loginDeviceHistoryRepository = loginDeviceHistoryRepository;
            _userRepository = userRepository;
        }

        public ResponseMessage Create(LoggedDeviceEntity model, string identity)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                model.ProfileID = identity;
                response.IsSuccess = _loginDeviceHistoryRepository.Create(model).Result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage Create(LoggedDeviceEntity model, User user)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                if (user == null)
                {
                    throw new UnauthorizedAccessException("Unauthorized!");
                }

                model.ProfileID = user.PublicID;
                response.IsSuccess = _loginDeviceHistoryRepository.Create(model).Result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<List<LoggedDeviceEntity>> GetAll(string identity)
        {
            ResponseMessage<List<LoggedDeviceEntity>> response = new ResponseMessage<List<LoggedDeviceEntity>>();

            try
            {
                User user = _userRepository.FindByUniq(identity.MakeItOriginal());

                if (user == null)
                {
                    throw new UnauthorizedAccessException();
                }

                response.ResultObject = _loginDeviceHistoryRepository.GetAll(user.PublicID);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                response.ResultObject = null;
            }

            return response;
        }
    }
}
