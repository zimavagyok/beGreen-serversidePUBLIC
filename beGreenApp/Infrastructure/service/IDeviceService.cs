using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface IDeviceService
    {
        ResponseMessage<Device> Create(Device entity);
        ResponseMessage<Device> Update(Device entity);
        ResponseMessage Delete(string id);
        ResponseMessage<DeviceResponse> GetByID(string id);
        ResponseMessage<List<DeviceResponse>> GetAll();
    }
}
