using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using beGreen.Model.Entity;
using beGreen.Model.Response;

namespace beGreen.Infrastructure.repository
{
    public interface IDeviceRepository
    {
        Device Create(Device entity);
        Device Update(Device entity);
        bool Delete(string id);
        DeviceResponse GetByID(string id);
        List<DeviceResponse> GetAll();
    }
}
