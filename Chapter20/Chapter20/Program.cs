using Chapter20;

public class Program
{
    public static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        Console.WriteLine(inventory.LookUpInventory(11));
        Console.ReadLine();

    }
}