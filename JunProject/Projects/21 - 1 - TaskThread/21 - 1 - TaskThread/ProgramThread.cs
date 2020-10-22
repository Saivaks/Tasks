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

            Console.WriteLine("Операция выполняется:");

            int countThread = 7;                                                                // Максимальное количество одновременно работающих потоков
            double[] mas = CreateMas((int)count, countThread);                                  // Создание массива
            double average = CalcMas(mas, countThread);                                         // Рассчет массива
            Console.WriteLine($"Среднее арифметрическое массива размерностью {mas.Length} : {average} .... mas.Average - {Math.Round(mas.Average(),10)}");
        }

        private static double[] CreateMas(int count, int countThread)
        {
            double[] mas = new double[count];
            int[] countTotalThread = new int [countThread];                                      // Количество отработанных потоков
            int oneThreadInterval = count / countThread;                                         // Интервал покрытия одного потока

            for (int i = 0; i < countThread;)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    int indexer = i++;
                    if (indexer < countThread)
                    {
                        Random rng = new Random();
                        int startIndex = indexer * oneThreadInterval;                           // Начальный индекс который покрывает поток a[x*lengthInterval]
                        int finishIndex;                                                        // Конечный  индекс который покрывает поток a[x*lengthInterval + n-1], где x - порядковый номер массива [0,countThread)

                        if (indexer != countThread - 1)                                         // Последний поток может обрабатывать больший интервал (интервал потока + остаток от деления)
                            finishIndex = (indexer + 1) * oneThreadInterval;
                        else
                            finishIndex = count;

                        for (; startIndex < finishIndex;)                                       // Заполняем массив на заданном интервале
                            mas[startIndex++] = rng.Next(100) + rng.NextDouble();

                        countTotalThread[indexer] = 1;

                        if (countTotalThread.Sum() == countThread)                              // Удостоверяемся, что завершаемый поток является последним, т.е. массив полностью заполнен                  
                            eventLocker.Set();                                                  // Подаем сигнал на продолжнеие работы (полного заполнения массива )    
                    }
                });
            }
            eventLocker.WaitOne();                                                              // Синхронизируем потоки

            return mas;
        }

        private static double CalcMas(double[] mas, int countThread)
        {
            int count = mas.Length;                                                             // Длина исследуемого массива
            double[] masSum = new double [countThread];                                         // Массив для записи результата сумм в каждом потоке
            int[] countTotalThread = new int [countThread];                                     // Количество выполненных потоков
            int oneThreadInterval = count / countThread;
            eventLocker.Reset();

            for (int i = 0; i < countThread;)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    int indexer = i++;
                    double localSum = 0;                                                        // Локальная переменная для хранения суммы элементов в массиве в заданном потоке
                    if (indexer < countThread)
                    {
                        int startIndex = indexer * oneThreadInterval;                           // Начальный индекс который покрывает поток
                        int finishIndex;                                                        // Конечный  индекс который покрывает поток

                        if (indexer != countThread - 1)
                            finishIndex = (indexer + 1) * oneThreadInterval;
                        else
                            finishIndex = count;

                        for (; startIndex < finishIndex; startIndex++)
                            localSum += mas[startIndex];                                        // Суммируем элементы на зданном интерфале

                        masSum[indexer] = localSum;                                             // Записываем сууму элементов даенного потока в массив сумм
                        countTotalThread[indexer] = 1;

                        if (countTotalThread.Sum() == countThread)                              // Удостоверяемся, что завершаемый поток является последним, т.е. полученна сумма всех элементов массива
                            eventLocker.Set();                                                  // Подаем сигнал на продолжнеие работы (полного обхода массива )  
                    }
                });
            }
            eventLocker.WaitOne();                                                              // Синхронизируем потоки

            return Math.Round(masSum.Sum() / count, 10);
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
