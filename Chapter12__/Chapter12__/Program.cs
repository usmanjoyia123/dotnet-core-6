using Chapter12__;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    public delegate int BinaryOperations(int a, int b);

    //public delegate void genericDelegate<T>(T a);
    public static void Main()
    {

        //MathClassDriver();
        //CarClassDriver();
        //genericDelegate<int> a = new genericDelegate<int>(IntegerTarget);
        //a(10);

        //genericDelegate<string> str = new genericDelegate<string>(StringTarget);
        //str("This is random string");
        Action<int> action = new Action<int>(IntegerTarget);
        Func<int, int, int> func = new Func<int, int, int>( (int x, int y) => {
            Console.WriteLine(x + y);
            return x + y;
        });

        int result = func(1,3);
        Console.WriteLine(result.ToString().GetHashCode());

        Console.WriteLine();

    }
    public static void CarClassDriver()
    {
        Car car = new Car("Civic", 180, 120);
        //car.RegisterWithCarEngine(new Car.CarEngineHandler(onCarChangeEvent));

        //group convention 
        car.RegisterWithCarEngine(onCarChangeEvent);
        car.RegisterWithCarEngine(onCarChangeEvent2);
        for (int i = 10; i <= 50; i+=10)
        {
//            car.Accelerate(i);
            Thread.Sleep(1000);
        }
        car._listOfHandlers.Invoke("he he he he");

    }

    public static void MathClassDriver()
    {
        BinaryOperations op = new BinaryOperations(SimpleMath.Add);
        op += SimpleMath.Subtract;
        int result = op.Invoke(4,5);
        op -= SimpleMath.Subtract;
        result = op.Invoke(6,7);
        Console.WriteLine(result);
        foreach(Delegate d in op.GetInvocationList())
        {
            Console.WriteLine(d.Target);
            Console.WriteLine(d.Method);
        }
    }
    public static void StringTarget(string msg) => Console.WriteLine(msg.ToUpper());

    public static void IntegerTarget(int msg) => Console.WriteLine(msg);
    public static void onCarChangeEvent(string msg) => Console.WriteLine("The message" +
        " from car is: " + msg);
    public static void onCarChangeEvent2(string msg) => Console.WriteLine(msg.ToUpper());
}