using System;
using System.Runtime.InteropServices;

namespace Shapes
{
    // Класс раширяющий класс Прямоугольник, и представляющий его в виде Куба
    public class Coub : Rectangle
    {
        public double Depth { get; protected set; }

        public Coub(double height, double width, double depth): base(height, width)
        {
            Depth = depth;
        }

        // Метод отвечающий за создание экземляра объекта и корректный ввод сторон прямоугольного параллелепипеда
        public new static Coub EnteringParameters()
        {
            var value = new double[3];
            string[] sideRectangle;
            do
            {
                Console.WriteLine("Введите стороны и высоту прямоугольного параллелепипеда через пробел:");
                sideRectangle = Console.ReadLine().Split(new char[] { ' ' });
            } while (!(sideRectangle.Length == 3 && Double.TryParse(sideRectangle[0], out value[0]) && Double.TryParse(sideRectangle[1], out value[1]) && Double.TryParse(sideRectangle[2], out value[2])));

            // Depth = value[2]; - Данные должны передаваться через конструктор. Так понимаю к этой строке.
            return new Coub(value[0], value[1], value[2]);
        }

        protected override double AreaCalc()
        {
            return Depth * Width * Height;
        }

        protected override double PerimeterCalc()
        {
            return 2 * (Depth * Height + Depth * Width + Height * Width);
        }

        public override string ToString()
        {
            return $"Площадь поверхности куба: {Perimeter} \nОбъем куба: \t\t  {Area}";
        }
    }
}
