using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Response
{
    public class UserResponse
    {
        public ProfileInfoResponse Info { get; set; }

        public UserResponse()
        {
            Info = new ProfileInfoResponse();
        }

        public UserResponse(string name, string profileImage, string email)
        {
            Info = new ProfileInfoResponse(name, profileImage, email);
        }

        public UserResponse(ProfileInfoResponse profile)
        {
            Info = new ProfileInfoResponse(profile.Name, profile.ProfileImage, profile.Email);
        }
    }
}
