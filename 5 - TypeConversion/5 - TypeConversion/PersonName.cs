using System;

namespace TypeConversion
{
    public class PersonName
    {
        public string FirstName { get; }
        public string LastName { get; }

        public PersonName(string lname, string fname)
        {
            FirstName = lname;
            LastName = fname;
        }

        // Неявное преобразование
        public static implicit operator string(PersonName person)
        {
            return $"{person.FirstName} {person.LastName}";
        }

        // Явное преобразование
        public static explicit operator PersonName(string value)
        {
            string[] mas = value.Split(new char[] { ' ' });
            if (mas.Length == 2)
                return new PersonName(mas[0], mas[1]);
            else
                throw new InvalidCastException("Данную строку невозможно привести к типу PersonName!");
        }

        public override string ToString()
        {
            return $"Last Name - {FirstName} \nFirst Name  - {LastName}";
        }

        // Для задачи с Equals and HashCode
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is PersonName))
                return false;
            PersonName person = (PersonName)obj;
            return this.FirstName == person.FirstName && this.LastName == person.LastName;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode()^FirstName.GetHashCode();
        }
    }
}
