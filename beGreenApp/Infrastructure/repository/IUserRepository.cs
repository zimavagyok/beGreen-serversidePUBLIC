using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using beGreen.Model.Entity;

namespace beGreen.Infrastructure.repository
{
    public interface IUserRepository
    {
        User Create(beGreen.Model.Entity.User entity);
        User Update(beGreen.Model.Entity.User entity);
        bool Delete(int id);
        bool Delete(string uniq);
        User GetByID(string id);
        List<User> GetAll();
        bool FindEmail(string email);
        User FindByCredencials(string email, string password);
        bool Deactivate(string PublicID);
        public User FindByUniq(string uniq);
    }
}
