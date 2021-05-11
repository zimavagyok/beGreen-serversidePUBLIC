using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;
using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Enums;
using beGreen.Model.Request;
using beGreen.Model.Response;
using beGreen.Services.Common;

namespace beGreen.Services
{
    public class SecurityService : ISecurityService
    {
        //private readonly string localhostEmailTemplatesPath = @"D:\beGreenApp\begreen.services\EmailTemplates";


        private readonly IUserRepository _userRepository;
        private readonly IAuditRepository _auditRepository;
        /*private readonly IDeviceRepository _deviceRepository;
        private readonly IManufacturerRepository _manufacturerRepository;*/
        private readonly IProfileRepository _profileRepository;
        /*private readonly IRecyclingBankRepository _recyclingBankRepository;
        private readonly IResetPasswordHashRepository _resetPasswordRepository;*/

        public SecurityService(IUserRepository userRepository, IAuditRepository auditRepository,
            /*IDeviceRepository deviceRepository, IManufacturerRepository manufacturerRepository,*/
            IProfileRepository profileRepository/*,IRecyclingBankRepository recyclingBankRepository, IResetPasswordHashRepository resetPasswordRepository*/)
        {
            _userRepository = userRepository;
            _auditRepository = auditRepository;
            //_deviceRepository = deviceRepository;
            //_manufacturerRepository = manufacturerRepository;
            _profileRepository = profileRepository;
            //_recyclingBankRepository = recyclingBankRepository;
            //_resetPasswordRepository = resetPasswordRepository;
        }

        public ResponseMessage<User> Create(RegisterUserRequest data)
        {
            ResponseMessage<User> response = new ResponseMessage<User>();

            try
            {
                //check if the user exists
                bool exist = _userRepository.FindEmail(data.Email);

                //if exist throw exeption
                if (exist == true)
                {
                    throw new Exception($"{data.Email} already taken!");
                }

                User user = new User(data);
                user.Password = PasswordHasher.Create(data.Password, data.Email);
                user.PublicID = UniqKeyGenerator.Generate();
                user.Role = UserRole.User.ToString();
                data.Role = UserRole.User.ToString();
                response.ResponseObject = _userRepository.Create(user);

                //create the profile
                Profile profile = new Profile(user.PublicID, data);
                response.IsSuccess = _profileRepository.Create(profile);

                //SendWelcomeEmail(user.Email);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public  ResponseMessage Delete(string uniq)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _userRepository.Delete(uniq);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public  ResponseMessage<User> FindByEmail(string email)
        {
            ResponseMessage<User> response = new ResponseMessage<User>();

            try
            {
                response.ResultObject = _userRepository.FindEmail(email);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public  ResponseMessage<User> FindByUniq(string uniq)
        {
            ResponseMessage<User> response = new ResponseMessage<User>();

            try
            {
                response.ResultObject = _userRepository.FindByUniq(uniq);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public  ResponseMessage<User> FindByCredencials(string email, string password)
        {
            ResponseMessage<User> response = new ResponseMessage<User>();

            try
            {
                response.ResponseObject = _userRepository.FindByCredencials(email, PasswordHasher.Create(password, email));
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public  ResponseMessage<List<User>> GetAll()
        {
            ResponseMessage<List<User>> response = new ResponseMessage<List<User>>();

            try
            {
                response.ResultObject = _userRepository.GetAll();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        #region Private Methods
        private async Task RecordDeviceLoggedInFrom(LoggedDeviceEntity userAgent, User user)
        {
            userAgent.ProfileID = user.PublicID;
            await _auditRepository.Create(userAgent);
        }

        private void SendWelcomeEmail(string email) //TODO: add CreateWelcomeEmailBody HTML template body
        {
            string emailBody = CreateWelcomeEmailBody(string.Empty);
            EmailSender.SendEmail(email, "Üdvözöllek a beGreen appban!", emailBody);
        }
        #endregion

        #region email templates

        private string CreateWelcomeEmailBody(string template)
        {
            string body = "Üdvözöllek a beGreen appban!";

            //using (StreamReader streamReader = new StreamReader(template))
            //{
            //    body = streamReader.ReadToEnd();
            //}

            // = body.Replace("{link}", link);

            return body;
        }
        #endregion
    }
}

