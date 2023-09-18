using Chapter7;
using System.Collections;
using System.Linq.Expressions;

class Program
{
    public static void Main(string[] args)
    { 
        CarTester();
        Console.ReadLine();
    }
    public static void demoTester()
    {
        demoTest d = new demoTest(10);
        try
        {
            for (int i = 0; i < 10; i++)
            {
                d.DriverFunction(i * 10);
            }
        }
        catch (InvalidDataException ex) when (ex.Message != null)
        {
            Console.WriteLine("I am invalid Exception block");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(ex.TargetSite);
        }
        catch (Exception ex)
        {
            Console.WriteLine("I am dad exception class");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(ex.TargetSite);
        }
    }
    public static void CarTester()
    {
        Car car = new Car("Usman", 20);
        car.CrankTunes(true);
        try
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(400);
                car.Accelerate(10);
                Thread.Sleep(400);
            }
        }
        catch (DeadCarException ex) 
        {
            Console.WriteLine("**I am DeadCarException Catch block**");

            Console.WriteLine("Message => {0}", ex.Message);
            Console.WriteLine("StackTrace => {0}", ex.StackTrace);
            Console.WriteLine("Source => {0}", ex.Source);
            Console.WriteLine("Member Name => {0}", ex.TargetSite);
            Console.WriteLine("Exception Class => {0}", ex.TargetSite.DeclaringType);
            Console.WriteLine("Member Function => {0}", ex.TargetSite.MemberType);
            if (ex.Data != null)
            {

                foreach (DictionaryEntry e in ex.Data)
                {
                    Console.WriteLine($"{e.Key} => {e.Value}");
                }
            }
            // throw new DeadCarException();
        }

        catch (ApplicationException ex)
        {
            Console.WriteLine("Application Exception");
        }

        catch (Exception ex)
        {
            Console.WriteLine("Message => {0}", ex.Message);
            Console.WriteLine("StackTrace => {0}", ex.StackTrace);
            Console.WriteLine("Source => {0}", ex.Source);
            Console.WriteLine("Member Name => {0}", ex.TargetSite);
            Console.WriteLine("Exception Class => {0}", ex.TargetSite.DeclaringType);
            Console.WriteLine("Member Function => {0}", ex.TargetSite.MemberType);
            if (ex.Data != null)
            {

                foreach (DictionaryEntry e in ex.Data)
                {
                    Console.WriteLine($"{e.Key} => {e.Value}");
                }
            }
        }
        finally
        {
            Console.ReadLine();
        }
    }
}