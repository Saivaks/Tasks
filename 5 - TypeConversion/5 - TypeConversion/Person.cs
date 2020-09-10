using System;

namespace _5___TypeConversion
{
    class Person
    {
        public string LastName { get; }
        public string FirstName { get; }

        public Person(string lname, string fname)
        {
            LastName = lname;
            FirstName = fname;
        }

        // Неявное преобразование
        public static implicit operator string(Person person)
        {
            return $"{person.LastName} {person.FirstName}";
        }

        // Явное преобразование
        public static explicit operator Person(string value)
        {
            string[] mas = value.Split(new char[] { ' ' });
            if (mas.Length == 2)
                return new Person(mas[0], mas[1]);
            else
                throw new InvalidCastException("Данную строку невозможно привести к типу Person!");
        }

        public override string ToString()
        {
            return $"Last Name - {LastName} \nFirst Name  - {FirstName}";
        }
    }
}
