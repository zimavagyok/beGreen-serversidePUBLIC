using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Request
{
    public class ChangeNameRequest
    {
        public string PublicID { get; set; }
        [Required]
        public string NewName { get; set; }

        public ChangeNameRequest()
        {
        }

        public ChangeNameRequest(string newName)
        {
            NewName = newName;
        }
    }
}
