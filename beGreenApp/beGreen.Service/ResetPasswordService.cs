using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;
using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Enums;
using beGreen.Model.Request;
using beGreen.Services.Common;

namespace beGreen.Services
{
    public class ResetPasswordService : IResetPasswordService
    {
        private readonly IResetPasswordHashRepository _resetPasswordHashRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;

        public ResetPasswordService(IResetPasswordHashRepository resetPasswordHashRepository,IUserRepository userRepository, IProfileRepository profileRepository)
        {
            _resetPasswordHashRepository = resetPasswordHashRepository;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        /*public ResponseMessage<bool> CreateLinkAsync(ForgotPasswordRequest model)
        {
            ResponseMessage<bool> response = new ResponseMessage<bool>();
            User user = null;

            try
            {
                //first find the user by the given email
                user.Email = _userRepository.FindEmail(model.Email);

                //if there is no registered user with the given email, we emmit error
                if (user == null)
                {
                    throw new Exception($"There are no registered user with the provided {model.Email} e-mail address.");
                }

                //now create the reset password token (a hash)
                string resetPasswordToken = ResetPasswordUrl.Create(user.PublicID);

                ResetPasswordHashEntity data = new ResetPasswordHashEntity(user.PublicID, resetPasswordToken);

                //insert the token in the database
                _resetPasswordHashRepository.Delete(user.PublicID);
                response.IsSuccess = _resetPasswordHashRepository.Create(data);

                string link = string.Empty;

                if (user.Role.ToLower() == UserRole.Agency.ToString().ToLower())
                {
                    link = $@"https://portalnekretnine.com/reset-password/" + $"{resetPasswordToken}/";
                }
                else
                {
                    link = $@"https://portalnekretnine.com/admin/reset-password/" + $"{resetPasswordToken}/";
                }


                //the email message text + link
#if DEBUG
               // string message = CreateResetPasswordEmailBody(@"D:\PortalNekretnine\Beckend\portalnekretnine.services\EmailTemplates\resetPassword.html", link);
#else
               // string message = CreateResetPasswordEmailBody(@"/var/www/portalnekretnine/EmailTemplates/resetPassword.html", link);
#endif

                //send the email
                //EmailSender.SendEmailAsync(model.Email, "portalnekretnine.com reset password url", message);

                response.ResultObject = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                response.ResultObject = false;

                _resetPasswordHashRepository.Delete(user.PublicID);
            }

            return response;
        }*/

        public ResponseMessage<bool> UpdatePassword(ResetPasswordRequest model)
        {
            ResponseMessage<bool> response = new ResponseMessage<bool>();

            try
            {
                //find the record using the resetPasswordToken
                ResetPasswordHashEntity data = _resetPasswordHashRepository.Find(model.ResetPasswordToken);

                //if no record was found using the token
                if (data == null)
                {
                    throw new Exception($"There has not been request for password reset on www.portalnekretnine.com");
                }

                //if record was found using the provided token
                //we check if it is still valid (token lives 5 minutes)
                DateTime now = DateTime.Now;
                double elipsedMinutes = now.Subtract(data.Date).TotalMinutes;

                if (elipsedMinutes > 100)
                {
                    //if token is expired we delete the record from the database
                    response.ResultObject = false;
                    _resetPasswordHashRepository.Delete(data.Uniq);
                    throw new Exception($"Reset token has expired!");
                }

                //if token is still active, then we update the database
                User user = _userRepository.FindByUniq(data.Uniq);
                user.Password = PasswordHasher.Create(model.Password, user.Email);
                _userRepository.Update(user);

                //after update delete the token data form DB
                _resetPasswordHashRepository.Delete(data.Uniq);

                response.ResultObject = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<bool> ChangePassword(ChangePasswordRequest model, string identity)
        {
            ResponseMessage<bool> response = new ResponseMessage<bool>();

            try
            {
                //find the user
                User user = _userRepository.FindByUniq(identity.Reverse());

                //validate the old password
                string password = PasswordHasher.Create(model.OldPassword, user.Email);
                if (user.Password != password)
                {
                    throw new Exception($"Old password doesn't match.");
                }

                //create the new password
                password = PasswordHasher.Create(model.NewPassword, user.Email);
                user.Password = password;

                //update user data
                _userRepository.Update(user);

                response.ResultObject = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        private string CreateResetPasswordEmailBody(string template, string link)
        {
            string body = string.Empty;

            using (StreamReader streamReader = new StreamReader(template))
            {
                body = streamReader.ReadToEnd();
            }

            body = body.Replace("{link}", link);

            return body;
        }
    }
}

