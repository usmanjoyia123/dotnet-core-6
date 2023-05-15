using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter20
{
    public class Car
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Color { get; set; }
        public string PetName { get; set; }
        public byte[] TimeStamp { get; set; }
    }
    public class CarViewModel : Car
    {
        public string Make { get; set; }
    }
}
