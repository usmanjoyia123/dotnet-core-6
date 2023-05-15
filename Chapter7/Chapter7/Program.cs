using Chapter7;
using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        Car car = new Car("Usman", 20);
        car.CrankTunes(true);
        try
        {
            for (int i = 0; i < 10; i++)
            {
                car.Accelerate(10);
            }
        }
        catch (DeadCarException ex) {
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
            //throw new DeadCarException();
        }

        catch (ApplicationException ex)
        {
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
        finally {
            Console.ReadLine();
        }       
    }
}