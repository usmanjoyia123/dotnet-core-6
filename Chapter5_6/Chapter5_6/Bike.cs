using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5_6
{
    internal class Bike
    {
        private int Id;
        private string Name;
        private string Description;
        private int currSpeed;
        private static string companyMake;
        public string firstProperty {
            set { this.Name = value; }
            get { return this.Name; }

        }
        public int ID {
            get => this.ID;
        }
        public static string CompanyMake {
            set => Bike.companyMake = value;
            get => Bike.companyMake;
        }
        public Bike(int id, string name) : this(id, name,"")
        {
            
            Bike.companyMake = "Honda";
        }

        public Bike(int Id, string Name, string Description) {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }
        public void changeSpeed(int delta) => currSpeed += delta;
        public string checkSpeed() => string.Format("The current speed of bike {0} is {1} MPH", this.Id, currSpeed);
    }
}
