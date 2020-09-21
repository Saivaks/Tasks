using System;

namespace TaskExtentions
{
    public class ProgramExtentions
    {
        public static void Main()
        {
            Console.WriteLine("\nЗадача: Реализовать методы расширения для класса int, для операций над TimeSpan. \nНапример 1,Seconds() = (TimeSpan) 00.00.01;\n");
            Random rng = new Random();

            Console.WriteLine("Секунды:");
            for (int i = 0; i < 10; i++)
                Console.Write($"{(rng.Next(0, 86400).Seconds()).ToString()} ");

            Console.WriteLine("\nМинуты:");
            for (int i = 0; i < 10; i++)
                Console.Write($"{(rng.Next(0, 1440).Minutes()).ToString()} ");

            Console.WriteLine("\nЧасы:");
            for (int i = 0; i < 10; i++)
                Console.Write($"{(rng.Next(0, 73).Hours()).ToString()} ");

            Console.WriteLine("\nКонец задачи.\n");
            Console.ReadKey();
        }
    }
}
