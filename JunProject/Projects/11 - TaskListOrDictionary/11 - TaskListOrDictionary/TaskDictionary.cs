using System;
using System.Collections.Generic;
using TaskEquals;

namespace TaskListOrDictionary
{
    public class TaskDictionary
    {
        public static void Main()
        {
            Console.WriteLine("\nЗадача: Реализовать упрощенную версию справочника места работ, где ключом является класс Person(ФИО, Дата рождения, Место рождения, Номер паспорта),\n" +
                               "значением - string(текущее место работы). В качестве результата работы должно быть следующее:"+
                               "\nВводим данные о физическом лице: ФИО, Дата рождения, Место рождения, Номерпаспорта и нам выдают его текущее место работы, "+ 
                               "если такой человек существует в нашей базе.\n");
            // Объявляем словарь
            Dictionary<Person, string> dictPersons = new Dictionary<Person, string>();
            string[] company = {"Microsoft", "Google", "MailRu","Oracle", "Cisco"};
            Person[] persons =
            {
                new Person("Bill Smit", new DateTime(1984, 2 , 28), "New York", 32 ),
                new Person("Tom Smites", new DateTime(1988,6,30),"Washington", 90 ),
                new Person("Иван Иванов", new DateTime(1993, 7, 1), "Москва", 15),
                new Person("Николай Петров", new DateTime(1978,7,3),"China",33 ),
                new Person("Bill Smites", new DateTime(1988,6,30),"China",666), 
            };

            // Заполняем словарь сгенерированными объектами и выводим их на экран
            for (int i=0;i<5;i++)
                dictPersons.Add(persons[i],company[i]);

            foreach (Person value in persons)
                Console.WriteLine(value.ToString());

            // Ищем в какой компании работает человек, с заданными параметрами. Поиск происходит до тех пор, пока польователь не введет Esc
            do
            {
                string value;
                Person person = CreatePerson();
                if (dictPersons.TryGetValue(person, out value))
                    Console.WriteLine($"\nCompany - {value}");
                else
                    Console.WriteLine("Параметра с такими значенем ключа не существует.");
                Console.WriteLine("If you want to finish entered \'Ecs\'");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("\nКонец задачи.\n");
            Console.ReadKey();
        }

        // Метод генерирующий объекты Person
        private static Person CreatePerson()
        {
            Console.Write("\nВведите ФИО через пробел (FirstName LastName): ");
            string name = Console.ReadLine();

            int age, month, day, id;

            Console.Write("Введите дату рождения (YYYY.MM.DD): ");
            string[] dateSplit = Console.ReadLine().Split(new char[] {'.',' '});
            if (!(dateSplit.Length==3 && Int32.TryParse(dateSplit[0], out age) && Int32.TryParse(dateSplit[1], out month) && Int32.TryParse(dateSplit[2], out day)) )
                throw new InvalidCastException("Невозможно преоразовать введенную строку в DateTime!");

            Console.Write("Введите название города: ");
            string city = Console.ReadLine();

            Console.Write("Введите ID: ");
            if (!Int32.TryParse(Console.ReadLine(), out id))
                throw new InvalidCastException("Невозможно преобразовать введенную строку в int!");

            return new Person(name, new DateTime(age, month, day), city, id );
        }
    }
}
