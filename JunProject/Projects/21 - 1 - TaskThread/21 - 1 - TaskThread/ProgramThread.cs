using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TaskThread
{
    public class ProgramThread
    {
        static EventWaitHandle eventLocker = new EventWaitHandle(false, EventResetMode.AutoReset);

        public static void Main()
        {
            Console.WriteLine("Генерировать и считать среднее арифметическое для массива размером в 10М и 100М элементов." +
                              "\nРеализовать 2 варианта, параллельные вычисления и без них, оценить результаты");

            // Создаим массивы для вычислений среднего арифметического размерностью в 10 000 000 и 100 000 000 элементов
            double[] mas10M = CreateMas(10000000);
            double[] mas100M = CreateMas(100000000);

            // Один поток
            Console.WriteLine("\nОдним потоком:");
            Console.ReadKey();
            CalculateExecutionTime(mas10M, 1);
            Console.ReadKey();

            CalculateExecutionTime(mas100M, 1);
            Console.ReadKey();

            // Несколько потоков
            Console.WriteLine("\nПри разделении задач по потокам:");
            Console.ReadKey();
            CalculateExecutionTime(mas10M, InputOfCountThreads());
            Console.ReadKey();

            CalculateExecutionTime(mas100M, InputOfCountThreads());
            Console.ReadKey();

            Console.WriteLine("\nКонец задачи.\n");
            Console.ReadLine();
        }

        // Метод для создания и заполнения массива размерностью - count - элементами
        private static double[] CreateMas(int count)
        {
            Console.WriteLine($"Начало генерации массива размерностью - {count}");
            Random rng = new Random();
            double[] mas = new double[count];

            for (int i = 0; i < mas.Length; i++)
                mas[i] = rng.Next(100) + rng.NextDouble();

            Console.WriteLine("Массив сгенерирован.");
            return mas;
        }

        // Метод рассчитывающий время затраченное на выполнение рассчета среднего арифметического заданного массива в потоках в колличестве - countThread 
        private static void CalculateExecutionTime(double[] mas, int countThread)
        {
            Stopwatch SW = new Stopwatch();
            Console.WriteLine($"Идет рассчет массива размерностью {mas.Length} в {countThread} потоке(ах) ...");
            SW.Start();
            double average = CalcMas(mas, countThread);
            SW.Stop();
            Console.WriteLine($"Среднее арифметрическое массива размерностью {mas.Length} : {average}");
            Console.WriteLine($"Время выполнения: {SW.Elapsed.Seconds} s {SW.Elapsed.Milliseconds} ms");
        }

        // Вввод количетсва работающих потоков
        private static int InputOfCountThreads()
        {
            int countThread;

            do
            {
                Console.Write("Введите количество одновременно работающих потоков - ");
            }
            while (!Int32.TryParse(Console.ReadLine(), out countThread));
            
            return countThread;
        }

        // Метод рассчета среднего арифметического в одном (countThread = 1) или нескольких потоках (countThread > 1)
        private static double CalcMas(double[] mas, int countThread)
        {
            int count = mas.Length;                                                             // Длина исследуемого массива
            double[] masSum = new double [countThread];                                         // Массив для записи результата сумм в каждом потоке
            int oneThreadInterval = count / countThread;                                        // Количетсво элементов массива в каждом потоке (Покрываемый интервал)
            int[] countTotalThread = new int[countThread];                                      // Массив состояний потоков 

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
                        countTotalThread[indexer] = 1;                                          // Помечаем, что поток отработал

                        if (countTotalThread.Sum() == countThread)                              // Удостоверяемся, что завершаемый поток является последним, т.е. полученна сумма всех элементов массива
                            eventLocker.Set();                                                  // Подаем сигнал на продолжнеие работы
                    }
                });
            }
            eventLocker.WaitOne();                                                              // Синхронизируем потоки

            return Math.Round(masSum.Sum() / count, 8);
        }
    }
}
