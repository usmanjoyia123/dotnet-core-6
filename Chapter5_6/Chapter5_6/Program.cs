namespace Chapter5_6
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Bike bike = new Bike(100, "CD-70", "Cheap Harley Davidson");
            bike.changeSpeed(5);
            Console.WriteLine( bike.checkSpeed());
            Bike.CompanyMake = "Yamaha";
            Console.WriteLine(Bike.CompanyMake);
            Bike bike1 = new Bike(100, "100CC");
            Console.WriteLine(Bike.CompanyMake);
            Console.ReadLine();
            Vehicle vehicle = new Vehicle(205, "Honda City", "Model 2023") { Make = "Honda", Id = 100 };
            Console.WriteLine(vehicle.Make);
            Console.WriteLine(vehicle.currSpeed);
            for (int i = 0;i < 10; i++) {
                vehicle.SpeedUp(5);
                Console.WriteLine(vehicle.currState());
            }
            Console.ReadLine();
        }
    }
}