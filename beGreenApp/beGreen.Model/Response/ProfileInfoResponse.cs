using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Response
{
    public class ProfileInfoResponse
    {
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }

        public ProfileInfoResponse()
        {
        }

        public ProfileInfoResponse(string name, string profilePicUrl, string email)
        {
            Name = name;
            ProfileImage = profilePicUrl;
            Email = email;
        }
    }
}
