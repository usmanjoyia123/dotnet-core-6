using Chapter_12;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
class program
{
    public static bool isEven(int i)
    {
        return (i % 2 == 0);
    }
    public static void Main()
    {
        
        Car car = new Car("GTR",100,10);
        
        CarCaller caller = new CarCaller();
        
        car.CarEngineAboutToBlow += caller.CarAboutToBlow;
        car.CarEngineAboutToBlow -= caller.CarAboutToBlow;
        car.CarEngineAboutToBlow += caller.CarIsAlmostDoomed;
        int counter = 0;

        Car.CarEngineHandler d = new Car.CarEngineHandler(delegate (string msg) {
            Console.WriteLine("=> Message from the car class: Speed is => {0}", msg);
        });
        car.CarEngineNormal -= d;
        
      
        Action<string> Anonymous = new Action<string>( (string msg) =>{ 
            Console.WriteLine($"I am anonymous action with message: {msg}");
        });

        car.CarEngineNormal += new Car.CarEngineHandler(Anonymous);

        car.CarEngineNormal -= new Car.CarEngineHandler(Anonymous);
        Car c = new Car("New Car", 100, 50);
        for (int i=0; i< 6; i++)
        {
            car.Accelerate(20);
        }
        Console.Clear();
        Func<int, int, int> constant = new Func<int, int, int>( (int _, int _) => { return 42; });
        Console.WriteLine(constant(3,4));

 //       Console.Clear();

        List<int> numbers = new List<int>();
        numbers.AddRange(new [] { 1, 2,3,4,5,6 });
       
        
        List<int> evenNumbers =  numbers.FindAll(delegate(int i) { return (i % 2 == 0); });
        List<int> oddNumbers = numbers.FindAll((int i) => {
            Console.WriteLine("Current value of i => {0}", i);
            bool  IsOdd = (i % 2 != 0);
            return IsOdd;
        });
        foreach (int number in oddNumbers)
        {
            Console.WriteLine(number);
        }
        Console.ReadLine();
    }
}