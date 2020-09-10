using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21___2____TaskThread
{
    public interface IJobExecutor
    {
        // Количество задач в очереди
        int Amount { get; }
        // Запуск обработки очереди и установка максимального количества одновременно выполняемых задач
        void Start(int maxConcurrent);
        // Остановка обработки очереди
        void Stop();
        // Добавление задачи в очередь
        void Add(Action action);
        // Очистка очереди
        void Clear();
    }
}
