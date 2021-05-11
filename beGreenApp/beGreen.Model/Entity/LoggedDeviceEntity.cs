using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace beGreen.Model.Entity
{
    public class LoggedDeviceEntity
    {
        public int Id { get; set; }
        public string ProfileID { get; set; }
        public string DeviceID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public LoggedDeviceEntity()
        { }

        public LoggedDeviceEntity(int id, string profile, string device)
        {
            Id = id;
            ProfileID = profile;
            DeviceID = device;
        } 
    }
}
