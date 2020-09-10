using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _5___TypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Person peson1 = new Person("Пименов", "Владимир");
            // Неявное преобразование
            string myName = peson1;
            Console.WriteLine($"неявное преобразование Person -> string: {myName}\n");

            // Явное преобразование
            Person person2 = (Person)myName;
            Console.WriteLine("Явное преобразование string -> Person:");
            Console.WriteLine(person2.ToString());

            Console.WriteLine("\nПользовательский ввод. Введите фамилию и имя:");
            string myName2 = Console.ReadLine();
            Console.WriteLine("Явное преобразование пользовательского ввода string -> Person:");
            Person person3 = (Person)myName2;
            Console.WriteLine(person3);

            // Equals Or ==
            Console.WriteLine($"\nExplicit - {peson1.Equals(myName)}"); // Для корректной работы метода, нужна его пергрузка в Person
            Console.WriteLine($"==       - {peson1 == myName}");      // Неявное преобразование с последующим сравнением

            Console.ReadKey();
        }
    }   
}
