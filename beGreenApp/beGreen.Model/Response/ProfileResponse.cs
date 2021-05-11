using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beGreen.Model.Response
{
    public class ProfileResponse : Entity.Profile
    {
        public ProfileResponse() { }

        public ProfileResponse(Entity.Profile profile)
        {
            if (profile != null)
            {
                ID = profile.ID;
                Name = profile.Name;
                DOB = profile.DOB;
                Email = profile.Email;
            }
        }

        /*public ProfileResponse(Entity.Profile profil, string email) : this(profil)
        {
            Email = email;
        }*/
    }
}
