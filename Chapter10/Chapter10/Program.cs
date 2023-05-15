using Chapter10;
using System.Collections;
using System.ComponentModel;

class Program
{
    public static void Main(string[] args)
    {
        string[] courses = { "CS4043" +
                "" +
                "", "CS3001", "CS4032" };
        
        for (int i = 0;i < courses.Length; i++)
        {
            Console.WriteLine(courses[i]);
        }
        foreach (string var in courses)
        {
            Console.WriteLine(var);
        }
        Array.Reverse(courses);

        foreach (var item in courses)
        {
            Console.WriteLine(item);
        }
        // Try to add a new item at the end?? Runtime error!
        //strArray[3] = "new item?";
        Array.Resize(ref courses,5); // makes a new array object in the memory
        for (int i = 0;i < courses.Length; i++)
            Console.WriteLine("Index:{0} and Value: {1}", i,courses[i]);
        // now let's check the array list 
        ArrayList arr = new ArrayList();
        arr.Add(1); // integer
        arr.AddRange(courses); // string array elements
        arr.AddRange(courses);
        arr.AddRange(courses);
        arr.Add("Usman");
//        Console.WriteLine ("Count: {0}",arr.Count);
  //      Console.WriteLine("Capacity :{0}",arr.Capacity);

        PersonCollection arrList = new PersonCollection();
        arrList.AddPerson(new Person ("Usman","Joyia",28));
        arrList.AddPerson(new Person("Usman", "Joyia", 28));
        arrList.AddPerson(new Person("Usman", "Joyia", 28));
        arrList.AddPerson(new Person("Usman", "Joyia", 28));

        arrList.AddPerson(new Person("Usman", "Joyia", 28));
        Console.WriteLine(arrList.Count);
        Console.WriteLine(arrList.Capacity);
        foreach (var item in arrList)
        { Console.WriteLine(item); }

       

        int a = 10, b = 5;
        Swap<int>(ref a, ref b);

        string fname = "Usman", Lname = "Joyia";
        Swap<string>(ref fname, ref Lname);

        GenericClass<int> g = new GenericClass<int>();
        g.X = a; g.Y = b;
        Console.WriteLine(g);


        Console.ReadLine();
    }

    static void Swap<T>(ref T x, ref T y)
    {
        Console.WriteLine("Values before the swapping\n x= {0}\n y = {1}", x, y);
        Console.WriteLine("The passed params are of type {0}", typeof(T));

        T tmp = x;
        x = y;
        y = tmp;
        //return tmp;
        Console.WriteLine("Values after the swapping\n x= {0}\n y = {1}", x, y);

    }
}