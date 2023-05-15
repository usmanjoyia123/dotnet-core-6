using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Car
    {
        public const int maxSpeed = 100;
        public int id { get; set; } = 123;
        public string ownerName { get; set; }
        public int currSpeed { get; set; }
        
        private readonly Radio musicBox = new Radio(); 

        private bool isDead;

        public Car() { }

        public Car(string name, int speed)
        {
            this.ownerName = name;
            this.currSpeed = speed; 
        }

        public void CrankTunes (bool state)
        {
            musicBox.TurnOn(state);
        }

        public void Accelerate (int delta)
        {
            if (isDead)
            {
                Console.WriteLine("The car is out of order {0}", this.ownerName);
            }
            else
            {
                this.currSpeed += delta;
                if (this.currSpeed > maxSpeed)
                {
                    isDead= true;
                    this.currSpeed = 0;
                    throw new DeadCarException($"The car is overheated and dead {this.ownerName}",
                        "A lot of raving", DateTime.Now);
                    //throw new DeadCarException($"")
                    //{
                    //    Data =
                    //    {
                    //        {"TimeStamp", $"the car is out of car at {DateTime.Now}" }
                    //        ,
                    //        {"Cause", "a lot of car raving" }
                    //    }
                    //};
                }
                else
                {
                    Console.WriteLine("Accelerating! The car is now => {0} MPH", this.currSpeed);
                }
            }
        }
    }
}
