using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}";
        }
    }
    
    public class PersonCollection : IEnumerable
    {
        private ArrayList _list = new ArrayList();
        public void AddPerson (Person person) => _list.Add(person);
        public int Count => _list.Count;
        public int Capacity => _list.Capacity;
        public Person GetPerson(int position) => (Person)_list[position];
        public void ClearPerson() => _list.Clear();
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}
