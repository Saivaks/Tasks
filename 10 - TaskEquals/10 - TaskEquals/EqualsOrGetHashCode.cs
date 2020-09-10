using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10___TaskEquals
{
    class EqualsOrGetHashCode
    {
        static void Main(string[] args)
        {
            // Создаем объекты для последующего сравнения.
            Person vladimir = new Person("Пименов Владимир", new DateTime(1994, 8, 19), "Тирасполь", 666999);
            Person andrei = new Person("Пименов Андрей", new DateTime(  2000, 12, 14), "Тирасполь", 668899);

            Person valadimirClone = new Person("Пименов Владимир", new DateTime( 1994, 8, 19), "Тирасполь", 666999);
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

            Console.ReadKey();
        }
    }
}
