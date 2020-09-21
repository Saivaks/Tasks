using System;
using Shapes;
using System.Collections;

namespace TaskEnumerable
{
    public class Enumeration
    {
        public static void Main()
        {
            Console.WriteLine("\nЗадача: Сделать пример множества и его членов, реализовать интерфейс для перечисления. Обойти всех членов при помощи операторов: foreach, while");
            Random rng = new Random();
            // Список объектов, содержащий внутри себя списки Фигур входящих в него
            ArrayList cartestianSpace = new ArrayList();

            // Генерируем списки объектов находящихся в декартовом просстранстве
            cartestianSpace.Add(GenerateShape<Circle>(rng.Next(1, 4)));
            cartestianSpace.Add(GenerateShape<Phere>(rng.Next(1, 4)));
            cartestianSpace.Add(GenerateShape<Rectangle>(rng.Next(1, 4)));
            cartestianSpace.Add(GenerateShape<Coub>(rng.Next(1, 4)));

            Console.WriteLine("\nПеречисление созданных объектов:");
            // Проходим по всем типам фигур находящихся в пространстве с помощью цикла foreach
            foreach (ArrayList indexList in cartestianSpace)
            {
                // Получаем перечислитель полученного списка фигур indexList, и обходим его в цикле while
                IEnumerator counter = indexList.GetEnumerator();
                while (counter.MoveNext())
                {
                    Shape valueShape = (Shape) counter.Current;
                    Console.WriteLine(valueShape.ToString()+"\n");
                }
            }

            Console.WriteLine("\nКоенц задачи.\n");
            Console.ReadKey();
        }

        // Метод генерирующий список объектов заданной фигуры в заданном количестве - count
        public static ArrayList GenerateShape<T>(int count) where T: new()
        {
            Console.WriteLine($"Создается {count} количество элементов:");
            ArrayList masArrayList = new ArrayList();

            for (int i=0;i<count;i++)
                masArrayList.Add(new T());

            return masArrayList;
        }
    }
}
