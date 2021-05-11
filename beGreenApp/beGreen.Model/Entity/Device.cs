using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace beGreen.Model.Entity
{
    public class Device
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Kötelező gyártót választani.", AllowEmptyStrings = false)]
        public int ManufacturerID { get; set; }

        [Required(ErrorMessage = "A model Namee kötelező adat.", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public string Model { get; set; }

        [Required(ErrorMessage = "A RAM megadása kötelező.", AllowEmptyStrings = false)]
        [Range(1, 16, ErrorMessage = "A RAM értéke csak egész szám lehet 1 - 16 közt.")]
        public int Ram { get; set; }

        [Required(ErrorMessage = "A kijelző mérete kötelező adat.", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public double ScreenSize { get; set; }


        [Required(ErrorMessage = "Az operációs rendszer kötelező adat.", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public string OperatingSystem { get; set; }


        public Device()
        { }

        public Device(string id, int ManufacturerId, string model, int ram, double screenSizee, string operatingSystem)
        {
            Id = id;
            ManufacturerID = ManufacturerId;
            Model = model;
            Ram = ram;
            ScreenSize = screenSizee;
            OperatingSystem = operatingSystem;
        }
    }
}
