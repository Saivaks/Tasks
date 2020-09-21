using System;
using Shapes;

namespace TaskComparable
{
    public class SortShapes
    {
        public static void Main()
        {
            Console.WriteLine("\nЗадача: Реализуйте класс произвольной фигуры (треугольник, квадрат, круг), определите CompareTo<T>," + 
                                "сравнение производим по площади фигуры, затем генерируйте 10 объектов и отсортируйте в порядке убывания.\n");

            // Создаем массив объектов Circle содержащий 10 элементов.
            Circle[] shapes = new Circle[10];
            for (int i = 0; i < 10; i++)
                shapes[i] = new Circle();

            Console.WriteLine("\nНеотсортированный массив:");
            ToPrint(shapes);

            // Проводим сортировку в порядке возрастания, согласно реализованному методу CompareTo, в классе  Shape, и меняем порядок элементов на обратный
            Console.WriteLine("\nОтсортированный убывающий массив:");
            Array.Sort(shapes);
            Array.Reverse(shapes);
            ToPrint(shapes);

            Console.WriteLine("Конец задачи.\n");
            Console.ReadKey();
        }

        // Метод отвечающий за виульно корректный вывод элементов массива на экран
        private static void ToPrint(Shape[] shapes)
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
