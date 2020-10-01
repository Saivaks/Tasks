﻿using System;
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

            int countThread = 7;                                                                // Максимальное количество одновременно работающих потоков
            double[] mas = CreateMas((int)count, countThread);                                  // Создание массива
            double sum = CalcMas(mas, countThread);                                             // Рассчет массива

            Console.WriteLine($"Среднее арифметрическое массива размерностью {mas.Length} : {sum/mas.Length}");
        }

        private static double[] CreateMas(int count, int countThread)
        {
            int countTotalThread = 0;                                                            // Количество отработанных потоков
            Random rng = new Random();
            object locker = new object();
            double[] mas = new double[count];
            int oneThreadInterval = count/countThread;                                           // Интервал покрытия одного потока

            for (int i = 0; i < countThread;)
            {
                ThreadPool.QueueUserWorkItem(x =>
                    {
                        int indexer = i++;
                        if (indexer < countThread)
                        {
                            Console.WriteLine($"Start thread create mas: {indexer + 1}");
                            int startIndex = indexer * oneThreadInterval;                       // Начальный индекс который покрывает поток
                            int finishIndex;                                                    // Конечный  индекс который покрывает поток

                            if (indexer != countThread - 1)
                                finishIndex = (indexer + 1) * oneThreadInterval;
                            else
                                finishIndex = count;

                            lock (locker)                                                       // Без lock происходит потеря данных
                                for (; startIndex < finishIndex;)
                                    mas[startIndex++] = rng.Next(100) + rng.NextDouble();

                            if (++countTotalThread == countThread)                              // Удостоверяемся, что завершаемый поток является последним, т.е. массив полностью заполнен                  
                                eventLocker.Set();                                              // Подаем сигнал на продолжнеие работы (полного заполнения массива )    

                            Console.WriteLine($"End thread create mas: {indexer+1}.");
                        }
                    });
            }
            eventLocker.WaitOne();                                                              // Синхронизируем потоки

            return mas;
        }

        private static double CalcMas(double[] mas, int countThread)
        {
            double sum = 0;
            int count = mas.Length;                                                         // Длина исследуемого массива
            int countTotalThread = 0;                                                       // Количество выполненных потоков
            object locker = new object();
            int oneThreadInterval = count / countThread;

            for (int i = 0; i < countThread;)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    int indexer = i++;
                    if (indexer < countThread)
                    {
                        Console.WriteLine($"Start thread sum: {indexer + 1}");
                        int startIndex = indexer * oneThreadInterval;                       // Начальный индекс который покрывает поток
                        int finishIndex;                                                    // Конечный  индекс который покрывает поток

                        if (indexer != countThread - 1)
                            finishIndex = (indexer + 1) * oneThreadInterval;
                        else
                            finishIndex = count;

                        lock (locker)                                                       // Суммируем элементы на зданном интерфале потока
                            for (; startIndex < finishIndex; startIndex++)
                                sum += mas[startIndex];

                        if (++countTotalThread == countThread)                              // Удостоверяемся, что завершаемый поток является последним, т.е. полученна сумма всех элементов массива
                            eventLocker.Set();                                              // Подаем сигнал на продолжнеие работы (полного обхода массива )  

                        Console.WriteLine($"End thread sum: {indexer + 1}.");
                    }
                });
            }
            eventLocker.WaitOne();                                                          // Синхронизируем потоки

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
