using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_12
{
    public class Car
    {
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // Is the car alive or dead?
        private bool _carIsDead;
        // Class constructors.
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        public delegate void CarEngineHandler(string msgForCaller);
        public event CarEngineHandler CarEngineExploded;
        public event CarEngineHandler CarEngineAboutToBlow;
        public event CarEngineHandler CarEngineNormal;
        public CarEngineHandler _listOfHandlers;
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            // _listOfHandlers = methodToCall;

            if (_listOfHandlers == null)
            {
                _listOfHandlers = methodToCall;
            }
            else
            {
                // Enabling multicasting delegate here
                //_listOfHandlers += methodToCall;
                _listOfHandlers = (CarEngineHandler)Delegate.Combine(_listOfHandlers, methodToCall);
            }
        }
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            // removing targets from multicast delegate
            _listOfHandlers -= methodToCall;
        }

            public void Accelerate(int delta)
        {
            if (_carIsDead)
            {
                CarEngineExploded?.Invoke("The car is dead fellas");
            }
            else
            {
                this.CurrentSpeed += delta;
                if ((this.MaxSpeed - this.CurrentSpeed) <= 10)
                {
                    CarEngineAboutToBlow?.Invoke("Watch out! Car can blow at max speed, Reaching soon\n");
                }
                if (this.CurrentSpeed >= this.MaxSpeed)
                {
                    _carIsDead = true;
                }
                else
                {
                    CarEngineNormal?.Invoke($"The current speed of car is {this.CurrentSpeed}");
                    //Console.WriteLine($"The current speed of car is {this.CurrentSpeed}");

                }
            }
        }
    }
}