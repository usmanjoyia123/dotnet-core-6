using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter21.TPH.Models
{
    public class Make: BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}
