using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chapter7
{
    public class demoTest
    {
        public const int maxValue = 100;
        public int currentValue;
        public demoTest() { }
        public demoTest(int value)
        {
            this.currentValue = value;
        }
        public void DriverFunction(int change)
        {
            if ((change + this.currentValue) <= maxValue)
            {
                this.currentValue += change;
                Console.WriteLine($"The current value is now {this.currentValue}");
            }
            else
            {
                throw new InvalidDataException($"The current value change is not allowed to go beyond {maxValue}");
            }
        }
    }
}
