using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Response
{
    public class EmailVerificationResponse
    {
        public bool IsEmailExists { get; set; } = false;

        public string Role { get; set; } = string.Empty;

        public EmailVerificationResponse()
        {
        }

        public EmailVerificationResponse(bool isEmailExists, string role)
        {
            IsEmailExists = isEmailExists;
            Role = role;
        }

        public EmailVerificationResponse(User user)
        {
            IsEmailExists = true;
            Role = user.Role;
        }
    }
}
