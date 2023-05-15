using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8
{
    // Multiple inheritance for interface types is A-okay.
    interface IDrawable
    {
        void Draw();
    }
    interface IPrintable
    {
        void Print();
        void Draw(); // <-- Note possible name clash here!
    }
    // Multiple interface inheritance. OK!
    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
    class Sqaure : IShape
    {
        public int GetNumberOfSides() => 4;
        public void Draw() => Console.WriteLine("Drawing...");
        public void Print() => Console.WriteLine("Printing...");
    }
}