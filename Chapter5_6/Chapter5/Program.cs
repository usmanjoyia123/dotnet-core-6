using Chapter5;

class Program
{
    public static void Main(string[] args)
    {
        
        //Car car = new Car() { Speed = 240 };
        //car.Speed = 240; 
        //Console.WriteLine(string.Format("My car is cruising at the speed of {0} MPH", car.Speed));

        //Console.WriteLine("***AFTER THE INHERITENCE***");
        //MiniVan miniVan = new MiniVan() { Speed = 100 };
        //Console.WriteLine(string.Format("Mini Van is cruising at the speed of {0} MPH", miniVan.Speed));
       
        
        //Employee e = new Employee();

        Manager chucky = new Manager("Fred Chucky", 35, 500, 230000, "348798247987", 45);
        chucky.GiveBonus(300);
       // chucky.DisplayStats();
        
        
        
        SalesPerson john = new SalesPerson("John Benin", 25, 199, 53000, "348798247987", 21);
       // john.DisplayStats();
        
        
        
        PTSalesPerson pT = new PTSalesPerson("Sample PT Employee", 19, 192, 12000, "7498378957948", 32, 5);
        //pT.DisplayStats();
        //Console.WriteLine(pT);

        object[] emps = { chucky, john, pT};

        foreach (Employee emp in emps)
        {
            //emp.DisplayStats();
            GivePromotion(emp);
        }
        //Console.WriteLine( pT.ToString());
        Console.ReadLine();
    }
    public static void GivePromotion(Employee e) // implicit casting here
        //but would not work for System.Object (only for is-a relationship)
        // As system would only know after the object is wrapped in the memory. 
        // requires the explicit casting for this mechanism
        //explicit casting makes the casting at run time
    {
        
        //Console.WriteLine("{0} is promoted!", e._empName); only get the footprinted properties
        if (e is SalesPerson s)
        {
            Console.WriteLine("{0} is promoted with {1} sales!!", s._empName, s.SalesNumber);
        }
        else if (e is Manager m)
        {
            Console.WriteLine("{0} is promoted with {1} sales!!", m._empName, m.stockOptions);
        }
        else if (e is Employee _) // Discard statement
        {
            Console.WriteLine("Unable to promote, wrong employee type {0} provided", e.GetType().Name);
        }
        // add a switch or if here to check if passed e is which type of employee
        // Print relevant properties afterwards!!

    }
}