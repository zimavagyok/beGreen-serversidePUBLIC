using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Request
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }

        public TokenRequest()
        { }

        public TokenRequest(string token)
        {
            Token = token;
        }
    }
}
