using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.repository
{
    public interface ILikeRepository
    {
        Like Create(Like entity);
        bool Delete(int id);
        bool DeleteByBoth(Like entity);
        Like GetByBoth(Like entity);
        int Count(int id);
    }
}
