using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using beGreen.Model.Request;
using beGreen.Model.Entity.Interfaces;

namespace beGreen.Model.Entity
{
    public class Profile
    {
        public string ID { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "A születési dátum kötelező adat", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [MaxLength(255)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "A név megadása kötelező", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public string Name { get; set; }

        public string ProfileImage { get; set; }

        public Profile() { }

        public Profile(string name, DateTime dob, string role,string email)
        {
            Name = name;
            DOB = dob;
            Role = role;
            Email = email;
        }
        public Profile(RegisterUserRequest data)
        {
            Name = data.Name;
            DOB = data.DOB;
            Role = data.Role;
            Email = data.Email;
        }
        public Profile(string id, RegisterUserRequest visitor)
        {
            ID = id;
            Name = visitor.Name;
            Role = visitor.Role;
            Email = visitor.Email;
            DOB = visitor.DOB;
        }
    }
}
