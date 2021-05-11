using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.repository
{
    public interface IDeviceProfileConnectionRepository
    {
        DeviceProfileConnection Create(DeviceProfileConnection entity);
        bool DeleteByDevice(string device);
        bool DeleteByProfile(string profile);
        List<DeviceProfileConnection> GetAll();
        List<DeviceProfileConnection> GetByDevice(string device);
        List<DeviceProfileConnection> GetByProfile(string profile);
        DeviceProfileConnection GetByBoth(DeviceProfileConnection device);
    }
}
