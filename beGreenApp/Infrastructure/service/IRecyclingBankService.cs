using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface IRecyclingBankService
    {
        ResponseMessage<RecyclingBank> Create(RecyclingBankCreateRequest data, string uniq);
        ResponseMessage Delete(string location);
        ResponseMessage<List<RecyclingBank>> GetAllClose(RecyclingBankRequest _recyclingBankRequest);
        ResponseMessage<List<RecyclingBank>> GetAll();
        ResponseMessage<int> GetByLocation(string location);
    }
}
