using beGreen.Model;
using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface IDeviceProfileConnectionService
    {
        ResponseMessage<DeviceProfileConnection> Create(DeviceProfileConnection entity);
        ResponseMessage DeleteByDevice(string device);
        ResponseMessage DeleteByProfile(string profile);
        ResponseMessage<List<DeviceProfileConnection>> GetByDevice(string device);
        ResponseMessage<List<DeviceProfileConnection>> GetByProfile(string device);
        ResponseMessage<DeviceProfileConnection> GetByBoth(DeviceProfileConnection device);
        ResponseMessage<List<DeviceProfileConnection>> GetAll();
    }
}
