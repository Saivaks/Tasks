using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _21___1___TaskThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch SW = new Stopwatch();

            // Один поток
            SW.Start();
            OneStream();
            SW.Stop();
            Console.WriteLine($"Время выполнения: {SW.Elapsed.Seconds} s {SW.Elapsed.Milliseconds} ms");

            // Два потока
            Console.WriteLine("При разделении задач по потокам:");
            SW.Reset();
            SW.Start();
            TwoStreams();
            SW.Stop();
            Console.WriteLine($"Время выполнения: {SW.Elapsed.Seconds} s {SW.Elapsed.Milliseconds} ms");
            Console.ReadLine();
        }

        public static void TwoStreams()
        {
            Thread thread10M = new Thread(new ParameterizedThreadStart (CreateMas));
            // Создание второго потока для генерации массива 10М и вычисления для него среднего арифметического 
            thread10M.Start(10000000);

            // Генерация массива 100М и вычисление для него среднего арифметического в основном потоке
            CreateMas(100000000);
        }

        public static void OneStream()
        {
            // Генерация массива 10М и вычисление для него среднего арифметического 
            CreateMas(10000000);

            // Генерация массива 100М и вычисление для него среднего арифметического 
            CreateMas(100000000);
        }

        public static void CreateMas(object count)
        {
            if (count is Int32)
            {
                Random rng = new Random();
                double[] mas = new double[(int)count];

                for (int i = 0; i < mas.Length; i++)
                    mas[i] = rng.Next(100) + rng.NextDouble();

                Console.WriteLine($"Среднее арифметрическое массива размерностью {mas.Length} : {mas.Average()}");
            }
            else
                throw new InvalidCastException("Невозможно преобразовать данный тип в Int32!");
        }
    }
}
