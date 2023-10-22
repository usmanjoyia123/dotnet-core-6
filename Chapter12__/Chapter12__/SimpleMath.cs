using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12__
{
    public class SimpleMath
    {
        public static int Add(int a, int b)
        {
            Console.WriteLine(a + ", " + b);
            return a + b;
        }
        public static int Subtract(int a, int b) => a - b;
    }
}
