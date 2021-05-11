using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace beGreen.Model.Entity
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A gyártó neve kötelező adat.", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public string Name { get; set; }

        public Manufacturer()
        { }
        public Manufacturer(string name)
        {
            Name = name;
        }

        public Manufacturer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
