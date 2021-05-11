using beGreen.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Entity
{
     public class RecyclingBank
    {
        public int Id { get; set; }
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

        public DateTime CreateDate { get; set; }

        public string Creator { get; set; }

        public RecyclingBank() { }
        public RecyclingBank(RecyclingBankCreateRequest data,string uniq)
        {
            Plastic = data.Plastic;
            Paper = data.Paper;
            WhiteGlass = data.WhiteGlass;
            ColouredGlass = data.ColouredGlass;
            Metal = data.Metal;
            Capacity = data.Capacity;
            Position = data.Position;
            Creator = uniq;
        }
        public RecyclingBank(bool plastic, bool paper, bool whiteGlass, bool colouredGlass, bool metal , int capacity, string position,string uniq)
        {
            Plastic = plastic;
            Paper = paper;
            WhiteGlass = whiteGlass;
            ColouredGlass = colouredGlass;
            Metal = metal;
            Capacity = capacity;
            Position = position;
            Creator = uniq;
        }
    }
}
