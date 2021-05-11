using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Request;
using beGreen.Repositories;
using beGreen.Services.Common;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;
using beGreen.Library.Extensions;

namespace beGreen.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;

        public UserService(IUserRepository userRepository, IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        public ResponseMessage<User> Create(RegisterUserRequest data)
        {
            //TODO: RegisterUserRequest beletenni minden olyan tulajdonsagot ami szukseges a User es a Profile objektumok letrehozasara
            ResponseMessage<User> response = new ResponseMessage<User>();

            try
            {
                User user = new User(data);
                user.Password = PasswordHasher.Create(data.Password, data.Email);
                user.PublicID = UniqKeyGenerator.Generate();
                response.ResponseObject = _userRepository.Create(user);

                Profile profile = data.ConvertTo<Profile>();
                profile.ID = user.PublicID;
                _profileRepository.Create(profile);


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

        public ResponseMessage<bool> MatchPassword(string password,string id)
        {
            ResponseMessage<bool> response = new ResponseMessage<bool>();

            try
            {
                User user = _userRepository.GetByID(id.Reverse());
                if(user.Password==PasswordHasher.Create(password,user.Email))
                {
                    response.ResponseObject = true;
                }
                else
                {
                    response.ResponseObject = false;
                }

                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<User> Update(ChangePasswordRequest changePasswordRequest)
        {
            ResponseMessage<User> response = new ResponseMessage<User>();
            User entity = GetByID(changePasswordRequest.PublicID).ResponseObject;

            try
            {
                changePasswordRequest.OldPassword = PasswordHasher.Create(changePasswordRequest.OldPassword, entity.Email);
                changePasswordRequest.NewPassword = PasswordHasher.Create(changePasswordRequest.NewPassword, entity.Email);
                if (entity.Password == changePasswordRequest.OldPassword)
                {
                    entity.Password = changePasswordRequest.NewPassword;
                    response.ResponseObject = _userRepository.Update(entity);
                    response.IsSuccess = true;
                    response.ErrorMessage = "Success";
                }
                else
                {
                    throw new Exception("Passowords don't match!");
                }
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
                response.IsSuccess = _userRepository.Delete(id);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage Delete(string uniq)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _userRepository.Delete(uniq);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage<beGreen.Model.Entity.User> GetByID(string id)
        {
            ResponseMessage<beGreen.Model.Entity.User> response = new ResponseMessage<beGreen.Model.Entity.User>();

            try
            {
                response.ResponseObject = _userRepository.GetByID(id.Reverse());
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

        public ResponseMessage<List<beGreen.Model.Entity.User>> GetAll()
        {
            ResponseMessage<List<beGreen.Model.Entity.User>> response = new ResponseMessage<List<beGreen.Model.Entity.User>>();

            try
            {
                response.ResponseObject = _userRepository.GetAll();
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
        public ResponseMessage Deactivate(string PublicID)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _userRepository.Deactivate(PublicID);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage<bool> FindEmail(string email)
        {
            ResponseMessage<bool> response = new ResponseMessage<bool>();

            try
            {
                response.ResponseObject = _userRepository.FindEmail(email);
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
        public ResponseMessage<User> FindByCredencials(string email,string password)
        {
            ResponseMessage<beGreen.Model.Entity.User> response = new ResponseMessage<beGreen.Model.Entity.User>();

            try
            {
                response.ResponseObject = _userRepository.FindByCredencials(email,password);
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
        public ResponseMessage<User> FindByUniq(string uniq)
        {
            ResponseMessage<User> response = new ResponseMessage<User>();

            try
            {
                response.ResponseObject = _userRepository.FindByUniq(uniq);
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
