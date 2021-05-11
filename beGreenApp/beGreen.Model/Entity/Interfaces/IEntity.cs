using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Model.Entity.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
