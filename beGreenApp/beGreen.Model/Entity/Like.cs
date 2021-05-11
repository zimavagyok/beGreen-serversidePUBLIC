using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Entity
{
    public class Like
    {
        public int Id { get; set; }
        public int RecyclingBankId { get; set; }
        public string ProfileId { get; set; }

        public Like() { }
        public Like(int recyclingbank, string profile)
        {
            RecyclingBankId = recyclingbank;
            ProfileId = profile;
        }
    }
}
