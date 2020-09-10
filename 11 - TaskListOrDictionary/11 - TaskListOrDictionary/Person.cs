using System;
using System.Collections.Generic;

namespace Persons
{
    // Класс Person из предыдущей задачи, описывающий человека
    class Person
    {
        public Name MyName { get; }
        public DateTime DateOfDirth { get; }
        public string City { get; }
        public int IdPass { get; }

        public Person(string name, DateTime date, string city, int id)
        {
            string[] nameSplit = name.Split(new char[] {' '});
            if (nameSplit.Length>=2)
                MyName = new Name(nameSplit[0],nameSplit[1]);
            else
                throw new InvalidCastException("Невозможно преобразовать строку: name => Name");

            DateOfDirth = date;
            City = city;
            IdPass = id;
        }

        public void ToPrint()
        {
            Console.WriteLine($"{MyName.ToPrint()} - {DateOfDirth.ToShortDateString()}");
            Console.WriteLine($"{City} - {IdPass}\n");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            Person person = (Person) obj;
            return this.MyName.Equals(person.MyName) && this.DateOfDirth == person.DateOfDirth
                                                     && this.City == person.City && this.IdPass == person.IdPass;
        }

        public override int GetHashCode()
        {
            return MyName.GetHashCode() + DateOfDirth.GetHashCode() + City.GetHashCode() + IdPass.GetHashCode();
        }
    }

    class Name
    {
        public string FirstName { get; }
        public string LastName { get; }

        internal Name (string lname, string fname)
        {
            FirstName = fname;
            LastName = lname;
        }

        public string ToPrint()
        {
            return $"{LastName} {FirstName}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Name))
                return false;
            Name name = (Name) obj;
            return this.LastName == name.LastName && this.FirstName == name.FirstName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }
    }
}
