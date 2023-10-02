using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    public class People<T, Z, W>
    {
        public T id;
        public Z name;
        public W age;
        public void SampleFunction<T,Z,W>(T a, Z b, W w)
        {
            // do some code here for this function
        }
        People() { }
        People(T a, Z b, W w)
        {
            this.id = a;
            this.name = b;
            this.age = w;
        }
    }
    public class GenericClass<T>
    {
        public T X; 
        public T Y;
        public T Z
        {
            get; set;
        }
        public GenericClass()
        {

        }
        public GenericClass(T x, T y) {
            this.X = x;
            this.Y = y;
        }
        public override string ToString() => $"{this.X} \n {this.Y} \n {this.Z}\n ";
    }
}
