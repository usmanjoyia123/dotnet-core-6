using Chapter11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_11
{
    public static class MyExtension
    {
        public static void ChangethePersonManager(this Person person)
        {
            person.Age = 10;
        }
        public static int ReverseDigits(this int i)
        {
            // Translate int into a string, and then
            // get all the characters.
            char[] digits = i.ToString().ToCharArray();
            // Now reverse items in the array.
            Array.Reverse(digits);
            // Put back into string.
            string newDigits = new string(digits);
            // Finally, return the modified string back as an int.
            return int.Parse(newDigits);
        }
        public static int CountDigits(this Person i)
        {
            return i.ToString().Length;
        }
    }
}
