using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    internal class SalesPerson:Employee
    {
        public int SalesNumber { get; set; }
        public SalesPerson(string name, int age, int id, float pay, string empSsn, int saleNumber)
            : base(name, age, id, pay, empSsn, _employeeBasePayType.Commision)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.CurrentPay = pay;
            //this.SSN = empSsn;
            this.SalesNumber= saleNumber;
        }
        public override sealed void GiveBonus(float amount) // next derived class cannot override this method now
        {
            int salesBonus = 0;
            if (this.SalesNumber > 0 && this.SalesNumber <= 100)
            {
                salesBonus = 10; // employs 10%
            }
            else if (this.SalesNumber > 100 && this.SalesNumber <= 300)
            {
                salesBonus = 20;
            }
            else if (this.SalesNumber > 300 && this.SalesNumber <= 500)
            {
                salesBonus = 30;
            }
            else
                salesBonus = 50;

            base.GiveBonus(amount + (amount * (salesBonus/100)));
        }
        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("The sales achieved by {0} are: {1}", this.Name, this.SalesNumber);
        }
    }
}
