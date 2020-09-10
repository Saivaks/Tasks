using System;
using System.Collections.Generic;
using System.Threading;

namespace _21___2____TaskThread
{

    class TaskQueue : IJobExecutor
    {
        Thread[] threads;
        private int totalCount = 0;
        Queue<Action> queueTasks = new Queue<Action>();

        public int Amount { get { return queueTasks.Count; } }

        public void Start(int maxConcurrent)
        {
            Console.WriteLine("\n\nStart:");
            threads = new Thread[maxConcurrent];
            while (Amount != 0)
            {
                for (int i = 0; i < maxConcurrent; i++)
                {
                    if ((threads[i] == null || threads[i].ThreadState == ThreadState.Stopped) && Amount!=0)
                    {
                        threads[i] = new Thread(new ThreadStart(queueTasks.Dequeue()));
                        threads[i].Name = $"Задача № {++totalCount} выполняется в потоке # {i+1}";
                        threads[i].Start();
                    }
                }
            }
        }

        public void Stop()
        {
            Console.WriteLine("Остановка потоков.");
            foreach (Thread thread in threads)
                thread.Abort();
        }

        public void Add(Action action)
        {
            queueTasks.Enqueue(action);
            Console.WriteLine($"В очередь добавлен поток под номером: {Amount}");
        }

        public void Clear()
        {
            Console.WriteLine("Очередь очищена.");
            queueTasks.Clear();
        }
    }
}
