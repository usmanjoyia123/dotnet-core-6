using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter21.TPH.Models
{
    public class Car : BaseEntity
    {
        public string Color { get; set; }
        public string PetName { get; set; }
        public int MakeId { get; set; }
        public Make MakeNavigation { get; set; }
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Radio RadioNavigation { get; set; }

        public IEnumerable<Driver> Drivers { get; set;} = new List<Driver>();
    }
}