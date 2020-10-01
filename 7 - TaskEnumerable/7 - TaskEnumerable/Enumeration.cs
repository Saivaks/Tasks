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

            // Список объектов, содержащий внутри себя списки Фигур входящих в него
            ArrayList cartestianSpace = new ArrayList();
            // Генерируем список объектов находящихся в декартовом просстранстве
            cartestianSpace.Add(GenerateShapes());

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

        // Метод генерирующий список объектов в декартовом простраснтве
        private static ArrayList GenerateShapes()
        {
            Random rng = new Random();
            ArrayList masArrayList = new ArrayList();
            int count = rng.Next(1, 4);

            Console.WriteLine($"Создается {count} количество элементов Circle:");
            for (int i=0;i<count;i++)
                masArrayList.Add(Circle.EnteringParameters());

            Console.WriteLine($"Создается {count = rng.Next(1, 4)} количество элементов Phere:");
            for (int i = 0; i < count; i++)
                masArrayList.Add(Phere.EnteringParameters());

            Console.WriteLine($"Создается {count = rng.Next(1, 4)} количество элементов Rectangle:");
            for (int i = 0; i < count; i++)
                masArrayList.Add(Rectangle.EnteringParameters());

            Console.WriteLine($"Создается {count = rng.Next(1, 4)} количество элементов Coub:");
            for (int i = 0; i < count; i++)
                masArrayList.Add(Coub.EnteringParameters());

            return masArrayList;
        }
    }
}
