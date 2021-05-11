using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface IUserService
    {
        ResponseMessage<User> Create(RegisterUserRequest data);
        ResponseMessage<User> Update(ChangePasswordRequest entity);
        ResponseMessage Delete(int id);
        ResponseMessage Delete(string uniq);
        ResponseMessage<beGreen.Model.Entity.User> GetByID(string id);
        ResponseMessage<List<beGreen.Model.Entity.User>> GetAll();
        ResponseMessage Deactivate(string PublicID);
        ResponseMessage<bool> FindEmail(string email);
        ResponseMessage<User> FindByCredencials(string email, string password);
        ResponseMessage<bool> MatchPassword(string password, string id);
    }
}
