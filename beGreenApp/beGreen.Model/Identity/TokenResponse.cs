using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Identity
{
    public class TokenResponse
    {
        public string access_token { get; set; }

        public double expires_in { get; set; }

        public TokenResponse()
        { }

        public TokenResponse(string accessToken, double expireTime)
        {
            access_token = accessToken;
            expires_in = expireTime;
        }
    }
}
