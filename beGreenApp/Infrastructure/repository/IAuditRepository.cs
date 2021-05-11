using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace beGreen.Infrastructure.repository
{
    public interface IAuditRepository
    {
        public Task<bool> Create(LoggedDeviceEntity entity);
        public bool Delete(string uniq);
        public LoggedDeviceEntity GetByID(string uniq);
        public List<LoggedDeviceEntity> GetAll();
        public List<LoggedDeviceEntity> GetAll(string uniq);
    }
}
