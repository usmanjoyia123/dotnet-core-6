using System.Xml.Linq;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.IO.Pipes;

class Program{
    static void getObjectDetails()
    {
        Console.WriteLine("=> System.Object Functionality:");
        // A C# int is really a shorthand for System.Int32,
        // which inherits the following members from System.Object.
        Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
        Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
        Console.WriteLine("12.ToString() = {0}", 12.ToString());
        Console.WriteLine("12.GetType() = {0}", 12.GetType());
        Console.WriteLine();
    }
    static void parseFromStrings()
    {
        Console.WriteLine("=> Data type parsing:");
        bool b = bool.Parse("True");
        Console.WriteLine("Value of b: {0}", b);
        double d = double.Parse("99.884");
        Console.WriteLine("Value of d: {0}", d);
        int i = int.Parse("8");
        Console.WriteLine("Value of i: {0}", i);
        char c = Char.Parse("w");
        Console.WriteLine("Value of c: {0}", c);
        // would produce errors if the data is not clean. We can use exception handling or TryParse()

        Console.WriteLine("=> String parsing with TryParse()");
        bool.TryParse("Hello", out bool a);
        Console.WriteLine("The bool parsing to string is: {0}", a);
        Console.WriteLine();

        bool.TryParse("1", out bool _a);
        Console.WriteLine("The bool parsing to string is: {0}", _a);
        Console.WriteLine();

        // covert this into separte function with proper success and failure checks [Hint: If-else control structures]
    }
    static void stringOperations()
    {
        //Strings are immutable in C#
        Console.WriteLine("**********Fun with String**********");
        //Escape Characters 
        Console.WriteLine("C:\\MyApp\\bin\\Debug ");
        Console.WriteLine("Everyone loves \"Hello World\" ");
        // Whitespace is preserved with verbatim strings.
        string myLongString = @"This is a very
                                very
                                    very
                                            long string";
        Console.WriteLine(myLongString);
        // Using string interpolation
        String name = "Your name";
        int age = 25;
        string greeting = string.Format("Hello {0} you are {1} years old.", name, age);
        string _greeting = $"Hello {name} you are {age} years old.";
        Console.WriteLine(greeting + "\n" + _greeting);
        //Verbatim strings can also be interpolated strings, by specifying both the interpolation operator ($) and the verbatim operator (@).
        string interp = "interpolation";
        string myLongString2 = $@"This is a very
                                                very
                                                    long string with {interp}";
        //New in C# 8, the order does not matter. Using either $@ or @$ will work.



        // checkout the Length property,
        // Compare(),
        // Contains(),
        // Equals() or "==" operator,
        // Format(),
        // Insert(),
        // PadLeft(),
        // Split(),
        // Trim(),
        // ToUpper(),
        // Replace(),
        // String Concatenation using "+" operator and Concat
        // String Builder and Append(), AppendLine()
    }

    static int Add(int a, int b) => a + b;
    static int[] ints(int[] marks) => marks;
    static int AddWrapper(int a, int b)
    {
        // Do some code here
        return Add();

        int Add()
        {
            return a + b;
        }
    }
    static void addusingParams(int x, int y, out int ans)
    {
        ans = x + y;
        x = 15;
        y = 20;
    }
    static (string code, string name, bool c) CourseInformation()
    {
        return ("CS4043", "Advanced Programming", true);
    }
    static string funWithSwitch(string colorBand)
    {
        return colorBand switch { 
            "Red"=>"#FF000",
            "Yellow" => "#FFB00",
            "Green" => "#FFA00",
            _ => "#FFFFF"
        };
    }

    static (string, int) funWithTupleSwitch(string code, string course) {
        return (code, course) switch
        {
            ("cs4041", "Advanced Programming") => ("ab 1", 23),
            ("CS2001", "Data Structures") => ("Room 11", 12),
            (_, _) => ("Seminar Hall", 12)
        } ; 
    }
    static void EvaluateEnum(System.Enum e)
    {
        Console.WriteLine("=> Information about {0}", e.GetType().Name);
        Console.WriteLine("Underlying storage type: {0}",
        Enum.GetUnderlyingType(e.GetType()));
        // Get all name-value pairs for incoming parameter.
        Array enumData = Enum.GetValues(e.GetType());
        Console.WriteLine("This enum has {0} members.", enumData.Length);
        // Now show the string name and associated value, using the D format
        for (int i = 0; i < enumData.Length; i++)
        {
            Console.WriteLine("Name: {0}, Value: {0:D}",
            enumData.GetValue(i));
        }
    }

    static void sampleFunction(params int [] values )
    {
        Console.Write(x+y);
        x = 100;
        y = 50;
        ans = x + y;
    }
    enum weekDays
    {
        Friday = 1,
        Saturday,
        Sunday, 
        Monday, 
        Tuesday, Wednesday, Thursday
    }
    static void Main(string[] args)
    {
        getObjectDetails();
        stringOperations();
        parseFromStrings();


        int[] marks = { 1, 2,3 };
        var subset = from i in marks where i < 3 select i;
        foreach (int i in subset) {
            Console.WriteLine(i);
        }

        object myItem = 123;
        Type T = typeof(string);
        char c = 'f';
        Console.WriteLine((myItem is int) ? $"{myItem} is Integer" : $"{myItem} is not Integer");
        Console.WriteLine((myItem is not string ? $"{myItem} is not String" : $"{myItem} is {T}"));
        if (c is > 'a' or <'A' and >= 'Z'){
            Console.WriteLine($"{c} is char variable");
        }

        int[] arr = new int[3];
        string[] strArr = {"Advanced Programming","Computer Networks","Artificial Intelligence" };
        bool[] flags = new bool[3] { false, true, true};
        int[,] matrix = new int[5, 5];
        var anonymous = new int[]{ 1,4,56,7};
        object[] objects = new object[5] {1, "Usman", "course", true, 3.45 };
        foreach (string str in strArr)
        {
            Console.WriteLine(str);
        }
        
        foreach (var o in objects)
        {
            Console.WriteLine($"Type of object is {o.GetType()} and value {o} ");
        }
        int[][] jaggedArray = new int[5][];
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            jaggedArray[i] = new int [i + 2];
        }

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j]+ "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"The lenght of arr is {arr.Length}");
        Console.WriteLine($"The lenght of strArr is {strArr.Length}");
        Console.WriteLine($"The lenght of flags is {flags.Length}");
        Console.WriteLine($"The lenght of matrix is {matrix.Length}");
        Console.WriteLine(funWithSwitch("Black"));
        Console.WriteLine(funWithTupleSwitch("cs21323","232234"));
        //lookout for the array methods such as clear(), Sort(), CopyTo(), Rank, Reverse()
        string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };
        Index id = ^3;
        Console.WriteLine(gothicBands[id]);
        for (int i = 1; i <= gothicBands.Length; i++)
        {
            Index idx = ^2;
            // Print a name
            //Console.WriteLine(gothicBands[idx] + ", ");
        }


        foreach (string gothic in gothicBands[0..2])
        {
            Console.WriteLine(gothic);
        }
        Console.WriteLine("Hello, World!");
        var today = weekDays.Tuesday;
        Console.WriteLine($"Today is weekday {today}");
        EvaluateEnum(weekDays.Tuesday);
        Console.ReadLine();
    }
}