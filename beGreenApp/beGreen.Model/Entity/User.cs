using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using beGreen.Model.Request;

namespace beGreen.Model.Entity
{
    public class User
    {
        public int ID { get; set; }

        public string PublicID { get; set; }

        [Required(ErrorMessage ="Az e-mail cím kötelező adat.",AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A jelszó megadása kötelező", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }
        
        public string Role { get; set; }

        public bool Deactivated { get; set; }

        public User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User(RegisterUserRequest data)
        {
            Email = data.Email;
            Password = data.Password;
            RegistrationDate = DateTime.Now;
            Role = data.Role;
        }
    }
}
