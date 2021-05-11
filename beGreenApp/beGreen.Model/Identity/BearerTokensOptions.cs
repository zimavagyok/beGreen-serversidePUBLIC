using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Identity
{
    public class BearerTokensOptions
    {
        public string Key { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public int AccessTokenExpirationTime { set; get; }
        public int RefreshTokenExpirationTime { set; get; }
    }
}
