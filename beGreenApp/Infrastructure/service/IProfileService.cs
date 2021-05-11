using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Request;
using beGreen.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface IProfileService
    {
        public ResponseMessage<bool> Create(Profile entity);
        ResponseMessage<Profile> Update(Profile entity);
        ResponseMessage<Profile> ChangeName(ChangeNameRequest entity);
        ResponseMessage Delete(int id);
        ResponseMessage<ProfileResponse> GetByID(string id);
        ResponseMessage<List<ProfileResponse>> GetAll();
        ResponseMessage<bool> FindUsername(string username);
    }
}
