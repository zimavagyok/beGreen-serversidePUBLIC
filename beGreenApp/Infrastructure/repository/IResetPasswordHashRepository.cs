using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Infrastructure.repository
{
    public interface IResetPasswordHashRepository
    {
        public bool Create(ResetPasswordHashEntity entity);
        public bool Delete(string uniq);
        public ResetPasswordHashEntity Find(string resetPasswordToken);
    }
}
