using beGreen.Model;
using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.service
{
    public interface IAuditService
    {
        public ResponseMessage Create(LoggedDeviceEntity model, string identity);
        public ResponseMessage Create(LoggedDeviceEntity model, User user);
        public ResponseMessage<List<LoggedDeviceEntity>> GetAll(string identity);
    }
}
