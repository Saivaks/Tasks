using System;

namespace Shapes
{
    // Класс описывающий геометрическую фигуру как Прямоугольник.
    public class Rectangle : Shape, IComparable<Rectangle>
    {
        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public Rectangle()
        {
            var valueRectangle = EnteringParameters();
            Width = valueRectangle[0];
            Height = valueRectangle[1];
            AreaCalc();
            PerimeterCalc();
        }

        // Конструктор для дальнейших задач
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
            AreaCalc();
            PerimeterCalc();
        }

        // Метод отвечающий за корректный ввод сторон Прямоугольника
        protected virtual double[] EnteringParameters()
        {
            var value = new double[2];
            string[] sideRectangle;
            do
            {
                Console.WriteLine("Введите длины сторон прямоугольника через пробел:");
                sideRectangle = Console.ReadLine().Split(new char[] { ' ' });
            } while (!(sideRectangle.Length == 2 && Double.TryParse(sideRectangle[0], out value[0]) && Double.TryParse(sideRectangle[1], out value[1])));

            return value;
        }

        protected override void AreaCalc()
        {
            Area = Width * Height;
        }

        protected override void PerimeterCalc()
        {
            Perimeter = 2 * (Height + Width);
        }

        public override string ToString()
        {
            return $"Периметр прямоугольника: \t{Perimeter} \nПлощадь прямоугольника: \t{Area}";
        }

        // Для задачи сортировки объектов
        public int CompareTo(Rectangle other)
        {
            return this.Area.CompareTo(other.Area);
        }
    }
}
