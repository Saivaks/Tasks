using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace TaskThread
{
    public class ProgramThread
    {
        static EventWaitHandle eventLocker = new EventWaitHandle(false, EventResetMode.AutoReset);

        public static void Main()
        {
            Console.WriteLine("Генерировать и считать среднее арифметическое для массива размером в 10М и 100М элементов."+
                              "\nРеализовать 2 варианта, параллельные вычисления и без них, оценить результаты");

            // Один поток
            Console.WriteLine("Одним потоком:");
            Console.ReadKey();
            OneStream();
            Console.ReadKey();

            // Два потока
            Console.WriteLine("При разделении задач по потокам:");
            Console.ReadKey();
            Streams();
            Console.ReadKey();

            Console.WriteLine("\nКонец задачи.\n");
            Console.ReadLine();
        }

        private static void Streams()
        {
            Stopwatch SW = new Stopwatch();
            // Генерация массива 10М и вычисление для него среднего арифметического 
            SW.Start();
            CreateAndCalcMasStreams(10000000);
            SW.Stop();
            Console.WriteLine($"Время выполнения: {SW.Elapsed.Seconds} s {SW.Elapsed.Milliseconds} ms");
            Console.ReadKey();

            // Генерация массива 100М и вычисление для него среднего арифметического 
            SW.Reset();
            SW.Start();
            CreateAndCalcMasStreams(100000000);
            SW.Stop();
            Console.WriteLine($"Время выполнения: {SW.Elapsed.Seconds} s {SW.Elapsed.Milliseconds} ms");
        }

        private static void CreateAndCalcMasStreams(object count)
        {
            if (!(count is Int32))
                throw new InvalidCastException("Невозможно преобразовать данный тип в Int32!");

            int countThread = 7;                                                                                    // Максимальное количество одновременно работающих потоков
            double average = CreateAndCalcMas((int)count, countThread);                                             // Рассчет массива

            Console.WriteLine($"Среднее арифметрическое массива размерностью {count} : {average}");
        }

        private static double CreateAndCalcMas(int count, int countThread)
        {
            double sum = 0;
            int countTotalThread = 0;                                                                                // Количество отработанных потоков
            int dimensionInterval = count / countThread;                                                             // Интервал покрытия одного потока

            Parallel.For(0, countThread, delegate (int i)
            {
                int indexer = i++;
                double localSum = 0;
                Random rng = new Random();                                                                          // Минимизируем общие элементы для всех потоков()
                int dimensionMas = dimensionInterval;

                if (indexer == countThread - 1)
                    dimensionMas = count - dimensionInterval * indexer - 1;                                          // Учитываем отстаток от деления

                double[] localMas = new double[dimensionMas];

                for (int index = 0; index < dimensionMas; index++)
                    localMas[index] = rng.Next(100) + rng.NextDouble();

                foreach (double value in localMas)
                    localSum += value;

                sum += localSum;

                if (++countTotalThread == countThread)
                    eventLocker.Set();
            });
            eventLocker.WaitOne();

            return sum/count;
        }

        private static void OneStream()
        {
            Stopwatch SW = new Stopwatch();
            // Генерация массива 10М и вычисление для него среднего арифметического 
            SW.Start();
            CreateAndCalcMasOneStream(10000000);
            SW.Stop();
            Console.WriteLine($"Время выполнения: {SW.Elapsed.Seconds} s {SW.Elapsed.Milliseconds} ms");

            // Генерация массива 100М и вычисление для него среднего арифметического 
            SW.Reset();
            SW.Start();
            CreateAndCalcMasOneStream(100000000);
            SW.Stop();
            Console.WriteLine($"Время выполнения: {SW.Elapsed.Seconds} s {SW.Elapsed.Milliseconds} ms");
        }

        private static void CreateAndCalcMasOneStream(object count)
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
