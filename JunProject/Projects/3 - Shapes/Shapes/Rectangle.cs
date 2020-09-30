using System;

namespace Shapes
{
    // Класс описывающий геометрическую фигуру как Прямоугольник.
    public class Rectangle : Shape, IComparable<Rectangle>
    {
        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        // Метод отвечающий за создание экземляра объекта и корректный ввод сторон Прямоугольника
        public static Rectangle EnteringParameters()
        {
            var value = new double[2];
            string[] sideRectangle;
            do
            {
                Console.WriteLine("Введите длины сторон прямоугольника через пробел:");
                sideRectangle = Console.ReadLine().Split(new char[] { ' ' });
            } while (!(sideRectangle.Length == 2 && Double.TryParse(sideRectangle[0], out value[0]) && Double.TryParse(sideRectangle[1], out value[1])));

            return new Rectangle(value[0], value[1]);
        }

        protected override double AreaCalc()
        {
            return Width * Height;
        }

        protected override double PerimeterCalc()
        {
            return 2 * (Height + Width);
        }

        public override string ToString()
        {
            return $"Периметр прямоугольника: {Perimeter} \nПлощадь прямоугольника:  {Area}";
        }

        // Для задачи сортировки объектов
        public int CompareTo(Rectangle other)
        {
            return this.Area.CompareTo(other.Area);
        }
    }
}
