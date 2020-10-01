using System;

namespace TaskEquals
{
    class EqualsOrGetHashCode
    {
        public static void Main()
        {
            Console.WriteLine("\nЗадача: Реализовать свой класс Person(ФИО, Дата рождения, Место рождения, Номер паспорта), переопределить в нём методы. GetHashCode и Equals\n");
            // Создаем объекты для последующего сравнения.
            Person vladimir = new Person("Пименов Владимир", new DateTime(1994, 8, 19), "Тирасполь", 6329);
            Person andrei = new Person("Пименов Андрей", new DateTime(2000, 12, 14), "Тирасполь", 6699);

            Person valadimirClone = new Person("Пименов Владимир", new DateTime(1994, 8, 19), "Тирасполь", 6329);
            Person andreiReference = andrei;

            // Используем для сравнения объектов переопределенный метод Equals()
            Console.WriteLine("Equals:");
            {
                Console.WriteLine($"Сравнение двух разных объеков с попомощью метода Equals: vladimir | andrei");
                vladimir.ToPrint(andrei);
                Console.WriteLine($"Result = {vladimir.Equals(andrei)}\n");

                Console.WriteLine($"Сравнение двух одинаковых объеков с попомощью метода Equals: vladimir | valadimirClone");
                vladimir.ToPrint(valadimirClone);
                Console.WriteLine($"Result = {vladimir.Equals(valadimirClone)}\n");

                Console.WriteLine($"Сравнение двух ссылок на один объект с попомощью метода Equals: andrei | andreiReference");
                andrei.ToPrint(andreiReference);
                Console.WriteLine($"Result = {andrei.Equals(andreiReference)}\n");
            }

            // Используем для сравнения объектов переопределенный метод GetHashCode
            Console.WriteLine("\n\n\nGetHashCode:");
            {
                Console.WriteLine($"Сравнение двух разных объеков с попомощью метода GetHashCode: vladimir | andrei");
                vladimir.ToPrint(andrei);
                Console.WriteLine($"Result: {vladimir.GetHashCode()} == {andrei.GetHashCode()} = {vladimir.GetHashCode() == andrei.GetHashCode()}\n");

                Console.WriteLine($"Сравнение двух одинаковых объеков с попомощью метода GetHashCode: vladimir | valadimirClone");
                vladimir.ToPrint(valadimirClone);
                Console.WriteLine($"Result: {vladimir.GetHashCode()} == {valadimirClone.GetHashCode()} = {vladimir.GetHashCode() == valadimirClone.GetHashCode()}\n");

                Console.WriteLine($"Сравнение двух ссылок на один объект с попомощью метода GetHashCode: andrei | andreiReference");
                andrei.ToPrint(andreiReference);
                Console.WriteLine($"Result: {andrei.GetHashCode()} == {andreiReference.GetHashCode()} = {andrei.GetHashCode() == andreiReference.GetHashCode()}\n");
            }

            Console.WriteLine("\nКонец задачи.\n");
            Console.ReadKey();
        }
    }
}
