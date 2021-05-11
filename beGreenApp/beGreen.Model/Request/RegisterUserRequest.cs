using beGreen.Model.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Request
{
    public class RegisterUserRequest
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public RegisterUserRequest() { }

        public RegisterUserRequest(string name, DateTime dob, string password, string email)
        {
            Name = name;
            DOB = dob;
            Password = password;
            Email = email;
            Role = "User";
        }

        public RegisterUserRequest(IVisitor visitor)
        {
            Name = visitor.Name;
            DOB = visitor.DOB;
            Password = visitor.Password;
            Email = visitor.Email;
            Role = "User";
        }
    }
}
