using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Identity
{
    public class JwtSettings
    {
        public string Audience { get; set; }
        public string Base64CertFile { get; set; }
        public string Issuer { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }

        public JwtSettings()
        { }

        public JwtSettings(JwtSettings jwtSettings)
        {
            if (jwtSettings == null)
            {
                return;
            }

            Audience = jwtSettings.Audience;
            Base64CertFile = jwtSettings.Base64CertFile;
            Issuer = jwtSettings.Issuer;
            Password = jwtSettings.Password;
            Key = jwtSettings.Key;
        }
    }
}
