using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beGreen.Model.Response
{
    public class DeviceResponse : Entity.Device
    {
        public string Manufacturer { get; set; }

        public DeviceResponse()
        { }

        public DeviceResponse(Entity.Device phone)
        {
            if (phone != null)
            {
                Id = phone.Id;
                ManufacturerID = phone.ManufacturerID;
                Model = phone.Model;
                Ram = phone.Ram;
                ScreenSize = phone.ScreenSize;
                OperatingSystem = phone.OperatingSystem;
            }
        }

        public DeviceResponse(Entity.Device phone, string manufacturer) : this(phone)
        {
            Manufacturer = manufacturer;
        }
    }
}
