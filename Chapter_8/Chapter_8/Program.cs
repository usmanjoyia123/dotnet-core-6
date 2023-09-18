using Chapter_8;
class Program
{
    public static void Main(string[] args)
    {
        // boxing and unboxing
        int number = 100;
        object obj = number; // wrapping the data into object

        int y = (int)obj; // unwrapping the data from object 

        Shape[] shapes = { new Triangle("Triangle", 15), new Circle("Circle", 4) };
        IPointy Ip = null;
        foreach (Shape s in shapes)
        {
            if (s is IPointy ip)

            {
                Console.WriteLine($"The points of {nameof(s)} are {ip.Points}");
            }
            try
            {
                s.Draw();
                Ip = (IPointy)s;
                Console.WriteLine(Ip.Points);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }
        } 
        Lazy <Circle>[] circles = new Lazy<Circle>[100];

        using Circle cr = new Circle("new circle", 4);
        Console.WriteLine(cr.PetName);
        //cr.Dispose();
        Console.WriteLine(cr.PetName);

        //Depending on the power of your system,
        //you might need to increase these values
        //CreateObjects(1_000_0000);
        ////Artificially inflate the memory pressure
        //GC.AddMemoryPressure(2147483647);
        //GC.Collect(0, GCCollectionMode.Forced);
        //GC.WaitForPendingFinalizers();

        Console.ReadLine();
    }

    // To test the finalizers aka destructors
    static void CreateObjects(int count)
    {
        Circle[] tonsOfObjects =
        new Circle[count];
        for (int i = 0; i < count; i++)
        {
            tonsOfObjects[i] = new Circle("", 0);
        }
        tonsOfObjects = null;
    }
}