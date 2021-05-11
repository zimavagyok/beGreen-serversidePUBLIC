using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Request
{
    public class TokenRefreshRequest : TokenRequest
    {
        /// <summary>
        /// Logged in user's device audit data
        /// </summary>
        [Required]
        public Device Audit { get; set; }

        public TokenRefreshRequest()
        { }

        public TokenRefreshRequest(string token, Device audit) : base(token)
        {
            Audit = audit;
        }
    }
}
