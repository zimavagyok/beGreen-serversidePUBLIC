using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using beGreen.Model.Entity;

namespace beGreen.Infrastructure.repository
{
    public interface IManufacturerRepository
    {
        Manufacturer Create(Manufacturer entity);
        Manufacturer Update(Manufacturer entity);
        bool Delete(int id);
        Manufacturer GetByID(int id);
        List<Manufacturer> GetAll();
        Manufacturer GetByName(string name);
    }
}
