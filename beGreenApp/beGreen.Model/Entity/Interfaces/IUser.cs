using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Entity.Interfaces
{
    public interface IUser
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Role { get; set; }
    }
}
