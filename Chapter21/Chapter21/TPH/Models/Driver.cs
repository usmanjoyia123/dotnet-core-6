using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter21.TPH.Models
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();

        public Person person { get; set; } = new Person();
        
    }
}
