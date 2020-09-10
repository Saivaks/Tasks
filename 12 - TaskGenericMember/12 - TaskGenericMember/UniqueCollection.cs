using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12___TaskGenericMember
{
    // Коллекцию которая хранит только уникальные объекты UniqueCollection<T>, при попытке добавить существующий инстанс, выбрасывает исключение.
    // Не наслеудется от List т.к. нам не нужен метод AddRange.
    class UniqueCollection<T>
    {
        private List<T> unicList = new List<T>();

        // Определяем функционал метода, для соответующей работы в нашей коллекции 
        public void Add(T value)
        {
            if (!Contains(value))
                unicList.Add(value);
            else
            {
                Console.WriteLine($"Exception!! Данный элемент \"{value}\" уже содержится в коллекции.\nНа момент возникновения ошибки коллекция содержала следующие элементы:");
                foreach (T valueList in unicList)
                    Console.Write($"{valueList} ");
                Console.ReadKey();
                throw new Exception("Данный элемент: уже содержится в коллекции");
            }
        }

        // Возвращает число элементов в unicList
        public int Count()
        {
            return unicList.Count;
        }

        // Определем пару стандартных методов для работы с нашей коллекцией

        public bool Contains(T value)
        {
            return unicList.Contains(value);
        }

        public T ElementAt(int index)
        {
            return unicList.ElementAt(index);
        }

        public int BinarySearch(T value)
        {
            return unicList.BinarySearch(value);
        }

        public int IndexOf(T value)
        {
            return unicList.IndexOf(value);
        }

        public void Insert(int index, T value)
        {
            unicList.Insert(index, value);
        }

        public bool Remove(T value)
        {
            return unicList.Remove(value);
        }

        public void RemoveAt(int index)
        {
            unicList.RemoveAt(index);
        }

        public void Sort()
        {
            unicList.Sort();
        }
    }
}
