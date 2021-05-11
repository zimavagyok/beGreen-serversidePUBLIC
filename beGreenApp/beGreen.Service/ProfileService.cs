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
using beGreen.Services.Common;
using beGreen.Model.Request;

namespace beGreen.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public ResponseMessage<bool> Create(Profile entity)
        {
            ResponseMessage<bool> response = new ResponseMessage<bool>();

            try
            {
                response.ResponseObject = _profileRepository.Create(entity);
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

        public ResponseMessage<Profile> Update(Profile entity)
        {
            ResponseMessage<Profile> response = new ResponseMessage<Profile>();

            try
            {
                response.ResponseObject= _profileRepository.Update(entity);
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
        public ResponseMessage<Profile> ChangeName(ChangeNameRequest entity)
        {
            ResponseMessage<Profile> response = new ResponseMessage<Profile>();
            Profile profileEntity = _profileRepository.GetByID(entity.PublicID.Reverse());

            try
            {
                profileEntity.Name = entity.NewName;
                response.ResponseObject = _profileRepository.ChangeName(profileEntity );
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
                response.IsSuccess = _profileRepository.Delete(id);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage<bool> FindUsername(string username)
        {
            ResponseMessage<bool> response = new ResponseMessage<bool>();

            try
            {
                response.ResponseObject = _profileRepository.FindUsername(username);
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
        public ResponseMessage<ProfileResponse> GetByID(string id)
        {
            ResponseMessage<ProfileResponse> response = new ResponseMessage<ProfileResponse>();

            try
            {
                response.ResponseObject = _profileRepository.GetByID(id.Reverse());
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

        public ResponseMessage<List<ProfileResponse>> GetAll()
        {
            ResponseMessage<List<ProfileResponse>> response = new ResponseMessage<List<ProfileResponse>>();

            try
            {
                response.ResponseObject = _profileRepository.GetAll();
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
