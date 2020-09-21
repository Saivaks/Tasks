using System;

namespace TaskSerialize
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person Alias;

        public Person()
        { }

        public Person(string fname, string lname, int age)
        {
            FirstName = fname;
            LastName = lname;
            Age = age;
        }

        public Person(string fname, string lname, int age, Person alias)
        {
            FirstName = fname;
            LastName = lname;
            Age = age;
            Alias = alias;
        }

        public void ToPrint()
        {
            Console.WriteLine($"FirstName - {FirstName}, LastName - {LastName}, Age - {Age}");
            if (Alias != null)
            {
                Console.WriteLine("Имеет псевдоним:");
                Alias.ToPrint();
            }
        }
    }
}
