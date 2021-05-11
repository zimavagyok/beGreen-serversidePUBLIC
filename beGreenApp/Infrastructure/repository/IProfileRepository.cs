using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using beGreen.Model.Entity;
using beGreen.Model.Response;

namespace beGreen.Infrastructure.repository
{
    public interface IProfileRepository
    {
        public bool Create(beGreen.Model.Entity.Profile entity);
        Profile Update(beGreen.Model.Entity.Profile entity);
        Profile ChangeName(beGreen.Model.Entity.Profile entity);
        bool Delete(int id);
        ProfileResponse GetByID(string id);
        List<ProfileResponse> GetAll();
        bool FindUsername(string username);
    }
}
