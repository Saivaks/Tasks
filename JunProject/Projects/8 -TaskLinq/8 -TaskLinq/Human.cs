using System;

namespace TaskLinq
{
    // Произвольный тип данных (строка, число, дата, bool)
    internal struct Human
    {
        internal int Age { get; }
        internal DateTime DateOfBirth { get; }
        internal bool Majority { get; }
        internal string FirstName { get; }

        internal Human(string firstName, DateTime date)
        {
            FirstName = firstName;
            DateOfBirth = date;
            Age = DateTime.Now.Year- date.Year;
            Majority = Age >= 18 ? true : false;
        }

        public override string ToString()
        {
            return $"{FirstName} - {Age}";
        }
    }
}
