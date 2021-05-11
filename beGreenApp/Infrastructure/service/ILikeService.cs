using beGreen.Model;
using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface ILikeService
    {
        ResponseMessage<Like> Create(Like entity);
        ResponseMessage Delete(int id);
        ResponseMessage DeleteByBoth(Like entity);
        ResponseMessage<Like> GetByBoth(Like entity);
        ResponseMessage<int> Count(int id);
    }
}
