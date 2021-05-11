using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface IResetPasswordService
    {
        //public ResponseMessage<bool> CreateLinkAsync(ForgotPasswordRequest model);
        public ResponseMessage<bool> UpdatePassword(ResetPasswordRequest model);
        public ResponseMessage<bool> ChangePassword(ChangePasswordRequest model, string identity);
    }
}
