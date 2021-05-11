using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Request
{
    public class EmailVerificationRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public EmailVerificationRequest()
        {
        }

        public EmailVerificationRequest(string email)
        {
            Email = email;
        }
    }
}
