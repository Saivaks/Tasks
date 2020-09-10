using System;
using Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9___TaskComparable
{
    class SortShapes
    {
        static void Main(string[] args)
        {
            // Создаем массив объектов Shape содержащий 10 элементов.
            Shape [] shapes = new Shape[]
            {
                new Circle(), new Circle(), new Circle(), 
                new Phere(), new Phere(), new Phere(), 
                new Rectangle(), new Rectangle(), new Rectangle(), 
                new Coub()
            };

            // Вычисляем для каждого объекта массива shapes, значение его площади
            foreach (Shape value in shapes)
                value.AreaCalc();

            Console.WriteLine("Неотсортированный массив:");
            ToPrint(shapes);

            // Проводим сортировку в порядке возрастания, согласно реализованному методу CompareTo, в классе  Shape, и меняем порядок элементов на обратный
            Console.WriteLine("Отсортированный убывающий массив:");
            Array.Sort(shapes);
            Array.Reverse(shapes);
            ToPrint(shapes);

            Console.ReadKey();
        }

        // Метод отвечающий за виульно корректный вывод элементов массива на экран
        public static void ToPrint(Shape[] shapes)
        {
            Console.Write("[");
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.Write($"{Math.Round(shapes[i].Area, 2)}");
                if (i!=shapes.Length-1)
                    Console.Write("|");
            }

            Console.WriteLine("]");
        }
    }
}
