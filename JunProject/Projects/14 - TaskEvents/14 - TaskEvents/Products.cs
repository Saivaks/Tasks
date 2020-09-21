using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TaskEvents
{
    // 1. Реализовать интерфейс INotifyPropertyChanged на произвольном классе, продемонстрировать его работу
    // 2. Реализовать очередь которая генерирует событие когда кол-во объектов в ней превышает n и событие когда становится пустой
    // Класс Products, определяющий наличие элементов на слкаде. Для реализации условий был унаследован функционал класса Queue, и переопределены методы
    // Добавления и удаления элементов из очереди, путем сокрытия методов. Также был реализован интерфейс INotifyPropertyChanged и  было реализовано событие PropertyChangedEventHandler
    internal class Products<T> : Queue<T> , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Queue<T> queueProducts = new Queue<T>();
        private int MaxCount { get; }

        internal Products(int max)
        {
            MaxCount = max;
        }

        internal new void Enqueue(T value)
        {
            queueProducts.Enqueue(value);
            if (queueProducts.Count> MaxCount)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Колличество элементов в очереди > MaxCount"));
        }

        internal new T Dequeue()
        {
            if(queueProducts.Count == 1)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("\nОчередь queueProducts = null\nLast Element: "));
            return queueProducts.Dequeue();
        }

        internal new int Count()
        {
            return queueProducts.Count;
        }
    }
}
