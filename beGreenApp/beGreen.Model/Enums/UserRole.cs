using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Enums
{
    [Flags]
    public enum UserRole
    {
        Anonymus = 0,
        Visitor = 1,
        User = 2,
        Admin = 3,
        Agency = 4
    }
}
