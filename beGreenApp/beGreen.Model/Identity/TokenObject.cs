using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Identity
{
    public class TokenObject
    {
        /// <summary>
        /// JWT
        /// </summary>
        public string Token { get; set; }

        public TokenObject()
        { }

        public TokenObject(string token)
        {
            Token = token;
        }
    }
}
