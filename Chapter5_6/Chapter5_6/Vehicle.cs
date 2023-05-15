using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5_6
{
    class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int currSpeed { get; set; }
        public string Make {
            get; init;
        }
        public Vehicle(int Id, string name, string description)
        {
            this.Id = Id;
            this.Name = name;
            this.Description = description;
        }
        public void SpeedUp(int delta) => this.currSpeed += delta;
        public string currState() =>  string.Format("The current speed of {0} vehicle is {1} MPH", this.Id, this.currSpeed);
    }
}
