using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Request
{
    public class RecyclingBankCreateRequest
    {
        public bool Plastic { get; set; }
        public bool Paper { get; set; }
        public bool WhiteGlass { get; set; }
        public bool ColouredGlass { get; set; }
        public bool Metal { get; set; }

        [Required(ErrorMessage = "A gyűjtő űrtartalma kötelező adat.", AllowEmptyStrings = false)]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "A pozíció kötelező adat.", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public string Position { get; set; }

        public RecyclingBankCreateRequest() { }
        
        public RecyclingBankCreateRequest(bool plastic, bool paper, bool whiteGlass, bool colouredGlass, bool metal, int capacity, string position)
        {
            Plastic = plastic;
            Paper = paper;
            WhiteGlass = whiteGlass;
            ColouredGlass = colouredGlass;
            Metal = metal;
            Capacity = capacity;
            Position = position;
        }
    }
}
