using Chapter_12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_12
{
    public class CarCaller
    {
        public CarCaller() { }
        public void CarAboutToBlow(string msg)
        {
            Console.WriteLine(msg);
        }
        public void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", msg);
        }
        public void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }
        public void CarIsNormal(string msg) {
            Console.WriteLine(msg);
        }
    }
}
