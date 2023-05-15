using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8
{
    public interface IPointy
    {
        int Points { set; get; }
     //   int Pointey() { return 0; }
    }
    abstract class Shape
    {
        protected Shape(string name = "NoName")
        {
            PetName = name;
        }
        public string PetName { get; set; }
        public virtual void Draw()
        {
            Console.WriteLine("Inside Shape.Draw()");
        }

    }
    class Triangle : Shape, IPointy
    {
        public int Points { get; set; }
        public Triangle(string name, int points):base (name) {
            this.Points= points;
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Triangle.Draw()");
        }
    }
    class Circle : Shape
    {
        public int Radius { set; get; }
        private bool _disposedValue;
        public Circle (string name, int radius):
            base (name)
        {
            this.Radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Inside Circle.Draw()");
            Console.Beep(); 
        }
        ~Circle () => Console.Beep();
    }
}
