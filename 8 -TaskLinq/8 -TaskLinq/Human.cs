using System;
using System.Data;

namespace _8__TaskLinq
{
    // Произвольный тип данных (строка, число, дата, bool)
    struct Human
    {
        public int Age { get; }
        public DateTime DateOfBirth { get; }
        public bool Majority { get; }
        public string FirstName { get; }

        public Human(string firstName, DateTime date)
        {
            FirstName = firstName;
            DateOfBirth = date;
            Age = DateTime.Now.Year- date.Year;
            Majority = Age >= 18 ? true : false;
        }

        public void ToPrint()
        {
            Console.WriteLine($"{FirstName} - {Age}; ");
        }
    }
}
