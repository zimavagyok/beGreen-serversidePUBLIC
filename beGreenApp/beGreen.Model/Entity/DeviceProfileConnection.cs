using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Entity
{
    public class DeviceProfileConnection
    {
        public string DeviceID { get; set; }
        public string ProfileID { get; set; }

        public DeviceProfileConnection() { }
        public DeviceProfileConnection(string device, string profile)
        {
            DeviceID = device;
            ProfileID = profile;
        }
    }
}
