using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13
{
    public class Car
    {
        public string PetName { get; set; } = "";
        public string Color { get; set; } = "";
        public int Speed { get; set; }
        public string Make { get; set; } = "";

        public Car() { }

        public Car (string name, string Color, string Make, int speed) { 
            this.PetName = name;
            this.Color= Color;
            this.Make = Make;
            this.Speed = speed;
        }
        public override string ToString()
        {
            return $"Name: {this.PetName}\t, Color: {this.Color}\t,  Make: {this.Make}\t, Speed: {this.Speed}\t";
        }
        public static List<Car> GetCarsBySpeed(List<Car> cars, int speed)
        {
            // Query Generic Syntax 

            // var result = from item in <container> where <BooleanExpression> select item; logical operators (&&, ||) for two or more Expressions
            var subset = from g in cars where g.Speed >= speed orderby g.PetName select g;
            return subset.ToList<Car>();
        }
        public static List<Car> GetCarsByName(List<Car> cars, string Name)
        {
            var subset = from g in cars where g.PetName == Name orderby g.PetName select g;
            return subset.ToList<Car>();
        }
        public static List<Car> GetCarsByMake(List<Car> cars, string Make)
        {
            var subset = from g in cars where g.Make == Make orderby g.PetName select g;
            return subset.ToList<Car>();
        }
        public static List<Car> GetCarsByColor(List<Car> cars, string Color)
        {
            var subset = from g in cars where g.Color == Color orderby g.PetName select g;
            return subset.ToList<Car>();
        }
        public static List<Car> GetCarsByColorAndMake(List<Car> cars, string Make, string Color)
        {
            var subset = from g in cars where g.Color == Color && g.Make == Make orderby g.Make select g;
            return subset.ToList<Car>();
        }
        public static void DisplaySubset(List<Car> subset)
        {
            foreach (var item in subset)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
