using System;
using TypeConversion;
using System.Collections.Generic;

namespace TaskEquals
{
    // Реализованный класс Person(ФИО, Дата рождения, Место рождения, Номер паспорта), с переопределенными в нём методами GetHashCode и Equals
    public class Person
    {
        public PersonName MyName { get; } // ФИО
        public DateTime DateOfBirth { get; }
        public string City { get; }
        public int IdPass { get; }

        public Person(string name, DateTime date, string city, int id)
        {
            MyName = (PersonName)name;
            DateOfBirth = date;
            City = city;
            IdPass = id;
        }

        public void ToPrint(Person objPerson)
        {
            Console.WriteLine($"{MyName.FirstName} {MyName.LastName} - {DateOfBirth.ToShortDateString()}\t|"+
                              $" {objPerson.MyName.FirstName} {objPerson.MyName.LastName} - {objPerson.DateOfBirth.ToShortDateString()}");
            Console.WriteLine($"{City} - {IdPass}\t\t| {objPerson.City} - {objPerson.IdPass}\n");
        }

        public override string ToString()
        {
            return $"{MyName.FirstName} {MyName.LastName} - {DateOfBirth.ToShortDateString()}, {City} - {IdPass} ";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            Person person = (Person) obj;
            return this.MyName.Equals(person.MyName) && this.DateOfBirth == person.DateOfBirth
                                                     && this.City == person.City && this.IdPass == person.IdPass;
        }

        public override int GetHashCode()
        {
            return IdPass^MyName.GetHashCode();
        }
    }
}
