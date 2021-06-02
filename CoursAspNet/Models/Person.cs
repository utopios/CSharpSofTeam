using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNet.Models
{
    public class Person
    {
        string firstName;
        string lastName;
        int id;
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Id { get => id; set => id = value; }

        public static List<Person> GetPersons()
        {
            return new List<Person>() { new Person() { Id=1,FirstName = "toto", LastName = "tata" }, new Person() { Id = 2,FirstName = "minet", LastName = "titi" }, };
        }
    }
}
