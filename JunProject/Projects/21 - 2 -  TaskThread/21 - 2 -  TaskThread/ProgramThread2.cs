using System;
using System.Collections.Generic;
using System.Threading;

namespace TaskThread2
{
    public class ProgramThread2
    {
        public static void Main()
        {
            Console.WriteLine("Задача: Реализовать очередь задач которая позволят добавлять задачи на исполнение из разных потоков одновременно и регулировать кол - во одновременно выполняемых задач. ");
            TaskQueue queue = new TaskQueue();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine(@"Выберете действие:
                1. Добавить задачу(и) в очередь;
                2. Запустить на выполнение;
                3. Остановить выполнение задач;
                4. Получить количество задач в очереди;
                5. Очистить очередь;
                6. Закончить работу.");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddTasks(queue);
                        break;
                    case "2":
                        QueueStart(queue);
                        break;
                    case "3":
                        queue.Stop();
                        break;
                    case "4":
                        Console.WriteLine($"На данный момент в очереди находится - {queue.Amount} поток(а)");
                        break;
                    case "5":
                        queue.Clear();
                        break;
                    case "6":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введен не верный номер задачи!");
                        break;
                }
            }

            Console.WriteLine("\nКонец задачи.\n");
        }

        private static void QueueStart(TaskQueue queue)
        {
            Console.WriteLine("Введите количество одновременно работающих потоков:");
            int count;
            if (int.TryParse(Console.ReadLine(), out count))
                queue.Start(count);

            else
                Console.WriteLine("Введенная строка не является целочисленным значением.");
        }

        private static void AddTasks(TaskQueue queue)
        {
            Action action = Task;
            Console.WriteLine("Введите количество добавляемых задач:");
            int count;
            if (int.TryParse(Console.ReadLine(), out count))
                for (int i = 0; i < count; i++)
                    queue.Add(action);
            else
                Console.WriteLine("Введенная строка не является целочисленным значением.");
        }

        private static void Task()
        {
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"Процесс выполнения задачи: - {i}0 %");
                Thread.Sleep(100);
            }
        }
    }
}
