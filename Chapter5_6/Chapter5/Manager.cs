using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    internal class Manager: Employee
    {
        public int stockOptions { get; set; }
        public Manager() { }
        // base keyword optimizes the calling of derived class object properties and constructor calls 
        public Manager (string fullName, int age, int empId, float currPay, string ssn, int numberOfOps)
            :base (fullName, age, empId, currPay, ssn, _employeeBasePayType.Salaried)
        {
            this.stockOptions = numberOfOps;
            //this.Name= fullName;
            //this.Age = age; 
            //this.SSN = ssn; as this was the readonly attribute of the base class
            this.CurrentPay= currPay;
        }
        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random random= new Random();
            this.stockOptions += random.Next(100,200);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("The Stocks Equity of {0} are: {1}", this.Name, this.stockOptions);
        }

      
    }
}
