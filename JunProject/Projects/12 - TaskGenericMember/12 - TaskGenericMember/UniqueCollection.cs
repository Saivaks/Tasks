using System;
using System.Collections;

namespace TaskGenericMember
{
    // Коллекцию которая хранит только уникальные объекты UniqueCollection<T>, при попытке добавить существующий инстанс, выбрасывает исключение.
    // По идее из всего списка коллекций наиболее эффективна Hashtable, отсортированный сиписок хешей коллекций, быстрый поиск и проверка, базовая достуность дублей
    internal class UniqueCollection<T>
    {
        private Hashtable unicCollection;

        internal UniqueCollection()
        {
            unicCollection = new Hashtable();
        }
            
        //  Добавить элемент типа T в коллекцию
        internal void Add(T value)
        {
            if (!(value == null || unicCollection.ContainsKey(value)))
                unicCollection.Add(value, value);
            else
            {
                Console.WriteLine($"Exception!! Данный элемент \"{value}\" уже содержится в коллекции.\nНа момент возникновения ошибки коллекция содержала следующие элементы:");
                foreach (DictionaryEntry valueList in unicCollection)
                    Console.Write($"{valueList.Value} ");
                Console.ReadKey();
                //throw new Exception("Данный элемент: уже содержится в коллекции"); - Закоментировал, чтобы не глушил весь метод
            }
        }

        internal void Remove(T value)
        {
            unicCollection.Remove(value);
        }

        internal ICollection GetValues()
        {
            return unicCollection.Values;
        }
    }
}
