using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Radio
    {
        public void TurnOn (bool on)
        {
            Console.WriteLine(on ? "Jamming" : "Quiet Time");

        }   
    }
}
