using System;

namespace Shapes
{
    // Класс раширяющий класс Прямоугольник, и представляющий его в виде Куба
    public class Coub : Rectangle
    {
        public double Depth { get; protected set; }

        public Coub()
        {
            Depth = EnteringDepth();
            AreaCalc();
            PerimeterCalc();
        }

        protected override double[] EnteringParameters()
        {
            var value = new double[2];
            string[] sideRectangle;
            do
            {
                Console.WriteLine("Введите длины сторон основания прямоугольного параллелепипеда через пробел:");
                sideRectangle = Console.ReadLine().Split(new char[] { ' ' });
            } while (!(sideRectangle.Length == 2 && Double.TryParse(sideRectangle[0], out value[0]) && Double.TryParse(sideRectangle[1], out value[1])));

            // Depth = value[2]; - Данные должны передаваться через конструктор. Так понимаю к этой строке.
            return value;
        }

        private double EnteringDepth()
        {
            double depth;
            do
            {
                Console.WriteLine("Введите высоту прямоугольного параллелепипеда:");
            } while (!Double.TryParse(Console.ReadLine(), out depth));

            return depth;
        }

        protected override void AreaCalc()
        {
            Area = Depth * Width * Height;
        }

        protected override void PerimeterCalc()
        {
            Perimeter = 2 * (Depth * Height + Depth * Width + Height * Width);
        }

        public override string ToString()
        {
            return $"Площадь поверхности куба: {Perimeter} \nОбъем куба: \t\t  {Area}";
        }
    }
}
