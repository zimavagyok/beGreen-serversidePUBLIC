using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Request
{
    public class ResetPasswordRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string ResetPasswordToken { get; set; }

        public ResetPasswordRequest()
        {
        }

        public ResetPasswordRequest(string passwoed)
        {
            Password = passwoed;
        }
    }
}
