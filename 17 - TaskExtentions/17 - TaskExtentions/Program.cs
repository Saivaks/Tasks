using System;

namespace _17___TaskExtentions
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine();
            Console.ReadKey();
        }
    }

    public static class IntExtentions
    {
        public static TimeSpan Seconds(this int second)
        {
            if (second<0||second>86400)
                throw  new ArgumentException("Exception!! Некорректный аргумент метода!");
            return new TimeSpan(00,00, second);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            if (minutes < 0 || minutes > 1440)
                throw new ArgumentException("Exception!! Некорректный аргумент метода!");
            return new TimeSpan(00,minutes,00);
        }

        public static TimeSpan Hours(this int hours)
        {
            if (hours < 0)
                throw new ArgumentException("Exception!! Некорректный аргумент метода!");
            return new TimeSpan(hours%24,00,00);
        }
    }
}
