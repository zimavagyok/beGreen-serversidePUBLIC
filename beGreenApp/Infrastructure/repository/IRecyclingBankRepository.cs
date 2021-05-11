using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using beGreen.Model.Entity;

namespace beGreen.Infrastructure.repository
{
    public interface IRecyclingBankRepository
    {
        RecyclingBank Create(RecyclingBank entity);
        bool Delete(string location);
        List<RecyclingBank> GetAll();
        int GetByLocation(string location);
    }
}
