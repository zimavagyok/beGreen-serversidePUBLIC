using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Entity.Interfaces
{
    public interface IVisitor : IUser
    {
        [Required]
        public string Name { get; set; }

        public string ProfileImage { get; set; }
        public DateTime DOB { get; set; }
    }
}
