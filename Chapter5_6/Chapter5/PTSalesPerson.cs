using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    sealed class PTSalesPerson : SalesPerson
    {
        public int workingHours {get;private set;}
        
        
        public PTSalesPerson(string name, int age, int id, float pay, string empSsn, int salePersonTag, int numberOfHours)
            : base(name, age, id, pay, empSsn, salePersonTag)
        {
            this.workingHours= numberOfHours;
        }

        public new void DisplayStats () // shadowing => opposite to overriding
        {
            base.DisplayStats();
            Console.WriteLine("Working hours {0}", this.workingHours);
        }
        public override string ToString() => $"{this.Name} have {this.workingHours} working hours with id {this.Id}";
    }
}
