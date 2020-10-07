using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace TaskThread2
{
    internal class TaskQueue : IJobExecutor
    {
        private CancellationTokenSource cancellationToken;
        private ConcurrentQueue<Action> queueTasks;
        private CancellationToken token;
        private Semaphore semaphore;
        private Task totalTask;

        public TaskQueue()
        {
            queueTasks = new ConcurrentQueue<Action>();
        }

        public TaskQueue(CancellationToken token)
        {
            queueTasks = new ConcurrentQueue<Action>();
            cancellationToken = new CancellationTokenSource();
            this.token = token;
        }

        public int Amount { get { return queueTasks.Count; } }

        public void Start(int maxConcurrent)
        {
            if (cancellationToken == null || token.IsCancellationRequested)
            {
                cancellationToken = new CancellationTokenSource();
                token = cancellationToken.Token;
                // Ограничиваем количество одновременно работающих потоков числом maxConcurrent
                semaphore = new Semaphore(maxConcurrent, maxConcurrent);

                totalTask = new Task(Run);
                totalTask.Start();
            }
            else
                Console.WriteLine("Программа уже запущена.");
        }

        private void Run()
        {
            while (!token.IsCancellationRequested)
            {
                if (Amount > 0)
                {
                    semaphore.WaitOne();
                    Task task = new Task(() =>
                   {
                       if (Amount > 0 && !token.IsCancellationRequested)
                       {
                           Action action;
                           queueTasks.TryDequeue(out action);
                           action?.Invoke();
                       }
                       semaphore.Release();
                   });
                    task.Start();
                }
                else
                {
                    Console.WriteLine("Задачи в очереди отсутсвуют - введите дополнительные задачи или остановите выполнение работы поотка.");
                    Thread.Sleep(1500);
                }
            }
        }

        public void Stop()
        {
            if (cancellationToken == null || cancellationToken.IsCancellationRequested)
                Console.WriteLine("Программа на данный момент не запущена или уже остановлена!");
            else
            {
                cancellationToken.Cancel();
                token = cancellationToken.Token;
                Console.WriteLine("Очередь остановлена.");
            }
        }

        public void Add(Action action)
        {
            queueTasks.Enqueue(action);
            Console.WriteLine($"В очередь добавлен поток под номером: {Amount}");
        }

        public void Clear()
        {
            queueTasks = new ConcurrentQueue<Action>(); // При использовании .Net Core 3.0+: queueTasks.Clear();
            Console.WriteLine("Очередь очищена.");
        }
    }
}
