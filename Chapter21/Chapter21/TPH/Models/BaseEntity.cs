using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter21.TPH.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
