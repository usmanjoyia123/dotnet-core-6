using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
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
