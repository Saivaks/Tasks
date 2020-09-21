using System;
using System.Diagnostics;
using System.Linq;
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
            OneStream();

            // Два потока
            Console.WriteLine("При разделении задач по потокам:");
            Streams();

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

            int countThread = 10; // Максимальное количество одновременно работающих потоков
            double[] mas = CreateMas((int)count, countThread);
            double sum = CalcMas(mas, countThread);

            Console.WriteLine($"Среднее арифметрическое массива размерностью {mas.Length} : {sum/mas.Length}");
        }

        private static double[] CreateMas(int count, int countThread)
        {
            Random rng = new Random();
            object locker = new object();
            int indexMas = count;
            double[] mas = new double[count];

            while (indexMas > 0)
                if (countThread > 0)
                {
                    countThread--;
                    ThreadPool.QueueUserWorkItem(x =>
                    {
                        lock (locker)
                        {
                            while (indexMas > 0)
                            {
                                if (indexMas-- > 0)
                                    mas[indexMas] = rng.Next(100) + rng.NextDouble();
                            }
                            eventLocker.Set();
                        }
                    });
                }
            eventLocker.WaitOne();

            return mas;
        }

        private static double CalcMas(double[] mas, int countThread)
        {
            double sum = 0;
            int indexMas = mas.Length;
            object locker = new object();

            while (indexMas > 0)
                if (countThread > 0)
                {
                    countThread--;
                    ThreadPool.QueueUserWorkItem(x =>
                    {
                        lock (locker)
                        {
                            while (indexMas > 0)
                            {
                                if (indexMas-- > 0)
                                    sum += mas[indexMas];
                            }
                            eventLocker.Set();
                        }
                    });
                }
            eventLocker.WaitOne();

            return sum;
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
