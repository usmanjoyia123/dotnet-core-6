using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    enum _employeeBasePayType
    {
        Executive = 120000,
        Salaried = 100000,
        Visiting = 50000, 
        Commision = 1000

    }
    abstract class Employee
    {
        _employeeBasePayType payType;   
        // Field data.
        public string _empName; // default is private for class attribtues
        public int _empId;
        private float _currPay;
        protected BenefitPackage benefitPackage = new BenefitPackage();
        // Constructors.
        public Employee() { }
        protected Employee(string name, int id, float pay) {
            _empName = name;
            _empId = id;
            _currPay = pay;
        }
        protected Employee(string name, int age, int id, float pay, string empSsn, _employeeBasePayType payType)
        {
            this._empName = name;
            this.Age = age;
            this._empId = id;
            this._currPay = pay;
            this.SSN= empSsn;
            this.payType = payType; 
        }
        //properties
        protected string Name { 
            get { return _empName; }
            set { _empName = value; }
        }
        protected int Id
        {
            get { return _empId; }
            set { _empId = value; }
        }
        protected float CurrentPay
        {
            get { return _currPay; }
            set { _currPay = value; }
        }
        protected string SSN { get; private set; }
        protected int Age { get; set; }

        
        // Expose object through a custom property. => delegation
        public BenefitPackage Benefits
        {
            get { return benefitPackage; }
            set { benefitPackage = value; }
        }
        // Methods.
        public virtual void GiveBonus(float amount) => _currPay += amount;
        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}", this._empName);
            Console.WriteLine("ID: {0}", this._empId);
            Console.WriteLine("Pay: {0}", this._currPay);
            Console.WriteLine("Employement Type: {0}", this.payType);
            Console.WriteLine("SSN: {0}", this.SSN);
        }
        // Expose certain benefit behaviors of object. => delegation
        public double GetBenefitCost() => benefitPackage.ComputePayDeduction();


        //public abstract void SampleFunction();
    }
}
