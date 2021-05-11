using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Entity
{
    public class ResetPasswordHashEntity
    {
        public string Uniq { get; set; }

        public string Hash { get; set; }

        public DateTime Date { get; private set; } = DateTime.Now;

        public ResetPasswordHashEntity()
        { }

        public ResetPasswordHashEntity(string uniq, string hash)
        {
            Uniq = uniq;
            Hash = hash;
            Date = DateTime.Now;
        }
    }
}
