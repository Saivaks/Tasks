using System;

namespace TaskGenericMember
{
    public class ProgramGenericMember
    {
        public static void Main()
        {
            Console.WriteLine("\nЗадача: Реализовать Коллекцию которая хранит только уникальные объекты UniqueCollection<T>, при попыткедобавить существующий инстанс, выбрасывает исключение.\n");

            string[] coll1 = { "Один","Два","Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять"};
            int[] colll2 = { 1,2,3,4,5,6,7,8,9};
            char[] coll3 = { 'О','Д','Т', 'Ч', 'П', 'Ш', 'С', 'В', 'Д' };

            UniqueCollection<string> uniqueCollectionString = CreateNewUniqueCollection<string>(coll1);
            ToPrint<string>(uniqueCollectionString);

            UniqueCollection<int> uniqueCollectionInt = CreateNewUniqueCollection<int>(colll2);
            ToPrint<int>(uniqueCollectionInt);

            UniqueCollection<char> uniqueCollectionChar = CreateNewUniqueCollection<char>(coll3);
            ToPrint<char>(uniqueCollectionChar);

            Console.WriteLine("Конец задачи.\n");
            Console.ReadKey();
        }

        // Метод генерирующий и заолняющий коллекцию UniqueCollection<T>
        private static UniqueCollection<T> CreateNewUniqueCollection<T>(T[] coll)
        {
            UniqueCollection<T> uniqColl = new UniqueCollection<T>();
            foreach (T value in coll)
                uniqColl.Add(value);
            return uniqColl;
        }

        // Метод выводящий элементы заданной коллекции на экран
        private static void ToPrint<T>(UniqueCollection<T> collection)
        {
            Console.WriteLine("Коллекция содержит следующие элементы:");
            foreach (T value in collection.GetValues())
                Console.Write($"{value} | ");
            Console.WriteLine("\n");
        }
    } 
}
