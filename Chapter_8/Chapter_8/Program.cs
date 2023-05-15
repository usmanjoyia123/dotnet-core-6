using Chapter_8;
class Program
{
    public static void Main(string[] args)
    {
        // boxing and unboxing
        int number = 100;
        object obj = number; // wrapping the data into object

        int y = (int)obj; // unwrapping the data from object 

        Shape[] shapes = { new Triangle("Triangle", 15), new Circle("Circle",4) };
        IPointy Ip = null;
        foreach (Shape s in shapes )
        {
            if (s is IPointy ip)
            {
                Console.WriteLine(ip.Points);
            }
            //try
            //{
            //    s.Draw();
            //    Ip = (IPointy)s;
            //    Console.WriteLine(Ip.Points);

            //}
            //catch (InvalidCastException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.Source);
            //}
        }
        Lazy <Circle>[] circles = new Lazy<Circle>[100];

        Circle cr = new Circle("new circle", 4);
        Console.WriteLine(cr.PetName);
        cr.Dispose();
        //Console.WriteLine(cr.PetName);
        Console.ReadLine();
    }
}