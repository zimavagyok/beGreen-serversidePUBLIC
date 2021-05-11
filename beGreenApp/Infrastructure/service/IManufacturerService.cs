using beGreen.Model;
using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface IManufacturerService
    {
        ResponseMessage<Manufacturer> Create(Manufacturer entity);
        ResponseMessage<Manufacturer> Update(Manufacturer entity);
        ResponseMessage Delete(int id);
        ResponseMessage<Manufacturer> GetByID(int id);
        ResponseMessage<List<Manufacturer>> GetAll();
        ResponseMessage<Manufacturer> GetByName(string name);
    }
}
