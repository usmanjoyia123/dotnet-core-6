using Chapter11;

class Program
{
    public static void Main(string[] args) {


        PersonCollection p = new PersonCollection();
        p[0] = new Person("Usman","Joyia");
        p[1] = new Person("Muhi o ","deen");
        p[2] = new Person("xyz","abc");
        p[3] = new Person("def","fed");
        p[4] = new Person("frg","grf");
        for (int j = 0; j < p.Count; j++)
        {
            Console.WriteLine("Index {0} = {1} ", j, p[j].FirstName);
        }

        List<Person> myPeople = new List<Person>();
        myPeople.Add(new Person("Lisa", "Simpson", 9));
        myPeople.Add(new Person("Bart", "Simpson", 7));
        // Change first person with indexer.
        myPeople[0] = new Person("Maggie", "Simpson", 2);
        // Now obtain and display each item using indexer.
        for (int i = 0; i < myPeople.Count; i++)
        {
            Console.WriteLine("Person number: {0}", i);
            Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
            Console.WriteLine("Age: {0}", myPeople[i].Age);
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}