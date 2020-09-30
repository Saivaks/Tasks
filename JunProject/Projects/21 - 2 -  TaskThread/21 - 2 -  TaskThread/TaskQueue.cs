using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace TaskThread2
{
    internal class TaskQueue : IJobExecutor
    {
        private CancellationTokenSource cancellationToken = new CancellationTokenSource();
        private ConcurrentQueue<Action> queueTasks = new ConcurrentQueue<Action>();
        private Semaphore semaphore;
        private Task totalTask;

        public int Amount { get { return queueTasks.Count; } }

        public void Start(int maxConcurrent)
        {
            semaphore = new Semaphore(maxConcurrent, maxConcurrent);

            totalTask = new Task(Run);
            totalTask.Start();
        }

        private void Run()
        {
            cancellationToken = new CancellationTokenSource();
            while (!cancellationToken.Token.IsCancellationRequested)
            {
                if (Amount > 0)
                {
                    Task task = new Task( () => 
                    {
                        semaphore.WaitOne();
                        if (Amount > 0 && !cancellationToken.Token.IsCancellationRequested)
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
                    Console.WriteLine("Задачи в очереди отсутсвуют.");
            }
        }

        public void Stop()
        {
            cancellationToken.Cancel();
            Console.WriteLine("Очередь остановлена.");
        }

        public void Add(Action action)
        {
            queueTasks.Enqueue(action);
            Console.WriteLine($"В очередь добавлен поток под номером: {Amount}");
        }

        public void Clear()
        {
            Console.WriteLine("Очередь очищена.");
            // queueTasks.Clear();  // Core 3.1
        }
    }
}
