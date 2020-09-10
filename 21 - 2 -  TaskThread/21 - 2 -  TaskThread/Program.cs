using System;
using System.Collections.Generic;
using System.Threading;

namespace _21___2____TaskThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = Task;
            TaskQueue queue = new TaskQueue();

            Console.WriteLine("Добавим 7 задач:");
            for (int i=0; i <15; i++)
                queue.Add(action);

            Console.WriteLine($"На данный момент в очереди находится - {queue.Amount} поток(а)");

            queue.Start(8);
            queue.Stop();
            Thread.Sleep(1000);

            for (int i = 0; i < 2; i++)
                queue.Add(action);
            Console.WriteLine($"На данный момент в очереди находится - {queue.Amount} поток(а)");
            queue.Clear();
            Console.WriteLine($"На данный момент в очереди находится - {queue.Amount} поток(а)");
            Console.ReadLine();
        }

        static public void Task()
        {
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($" {Thread.CurrentThread.Name}. Процесс выполнения задачи: - {i}0 %");
                Thread.Sleep(100);
            }
        }
    }
}
