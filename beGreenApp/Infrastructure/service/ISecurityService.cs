using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Request;
using beGreen.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface ISecurityService
    {
        ResponseMessage<User> Create(RegisterUserRequest data);
        ResponseMessage Delete(string uniq);
        ResponseMessage<User> FindByEmail(string email);
        ResponseMessage<User> FindByUniq(string uniq);
        ResponseMessage<User> FindByCredencials(string email, string password);
        ResponseMessage<List<User>> GetAll();
    }
}
