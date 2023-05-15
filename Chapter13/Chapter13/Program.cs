using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter13;
namespace Chapter13 { 
    class Program
    {
        public static void Main(string[] args)
        {
            
            Car c = new Car ("City", "White", "Honda", 120);
            Car c1 = new Car {
                PetName = "Yaris",
                Color = "Red",
                Make = "Toyota", 
                Speed = 120
            };
            Console.Clear();

            List < Car > Showroom = new List<Car>() {
                c, c1,
                new Car (){ PetName = "Civic", Color = "Black", Make= "Honda", Speed = 180},
                new Car ("Corolla", "Silver", "Toyota", 130),
                new Car ("Vitz", "Red", "Toyota", 100),
                new Car ("Swift", "White", "Suzuki", 110),
                new Car ("Grande", "Black", "Toyota", 180),
                new Car ("Prius", "Black", "Toyota", 160),
                new Car ("Sportage", "White", "KIA", 150)
            };

            Console.WriteLine("***Cars by Speed***\n");
            var cars_speed = Car.GetCarsBySpeed(Showroom, 110);
            Car.DisplaySubset(cars_speed);

            Console.WriteLine("***Cars by Make***\n");

            var cars_make = Car.GetCarsByMake(Showroom, "Honda");
            Car.DisplaySubset(cars_make);

            Console.WriteLine("***Cars by Name ***\n");
            var cars_name = Car.GetCarsByName(Showroom, "City");
            Car.DisplaySubset(cars_name);

            Console.WriteLine("***Cars by Color **\n");
            var cars_color = Car.GetCarsByColor(Showroom, "White");
            Car.DisplaySubset(cars_color);

            Console.WriteLine("*** Cars by Make and Color ***\n");
            var cars_MakeColor = Car.GetCarsByColorAndMake(Showroom, "Honda",  "White");
            Car.DisplaySubset(cars_MakeColor);

            Car.DisplaySubset(c.GetAllData(Showroom));

            Console.Clear();


            Console.WriteLine("\n\n Projected Types \n\n");
            foreach (var item in c.GetProjectedSubset(Showroom))
            {

                Console.WriteLine($"{item.GetType().Name}: \t {item}");
            }

          
            Console.WriteLine("\n\n Difference in the result\n\n");
            Car.DisplaySubset(c.DisplayDiff(Showroom, Showroom));
            Console.Clear();

            // chunks
            IEnumerable<Car[]> chunks = (from g in Showroom select g).Chunk(3);
            int i = 0;
            foreach( var item in chunks)
            {
                Console.Write("Chunk {0}:\n\n\n", i++);
                foreach (var data in item)
                {
                    Console.WriteLine(data.ToString());
                }
            }
            Console.Clear();

            Console.Clear();
            int[] Temps = { 45, 35, 44, 54, 46 };
            var query = (from g in Temps orderby g descending select g).First();

            Console.WriteLine("The Maximum Temp is {0}", query.ToString());

            Console.WriteLine("The Second Maximum" +
                " Temp is {0}", (from g in Temps orderby g descending select g).Skip(1).First());
            
            // Various aggregation examples.
            
            Console.WriteLine("Max temp: {0}",
            (from t in Temps select t).Max());
            Console.WriteLine("Min temp: {0}",
            (from t in Temps select t).Min());
            Console.WriteLine("Average temp: {0}",
            (from t in Temps select t).Average());
            Console.WriteLine("Sum of all temps: {0}",
            (from t in Temps select t).Sum());

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}