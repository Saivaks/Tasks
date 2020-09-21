using System;

namespace Shapes
{
    // Класс описывающий геометрическую фигуру как Круг.
    public class Circle : Shape, IComparable<Circle>
    {
        public double Radius { get; protected set; }

        public Circle()
        {
            Radius = EnteringParameters();
            AreaCalc();
            PerimeterCalc();
        }

        // Метод отвечающий за корректный ввод радиуса круга
        protected virtual double EnteringParameters()
        {
            double radius;
            do
            {
                Console.Write("Введите радиус круга: R - ");
            } while (!Double.TryParse(Console.ReadLine(), out radius));

            return radius;
        }

        protected override void AreaCalc()
        {
            Area = Math.PI * Radius * Radius;
        }

        protected override void PerimeterCalc()
        {
            Perimeter = 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Периметр круга: {Perimeter} \nПлощадь круга: \t{Area}";
        }

        // Для задачи преобразования типов
        public Circle(double radius)
        {
            Radius = radius;
            AreaCalc();
            PerimeterCalc();
        }

        public static implicit operator double[] (Circle circle)
        {
            return new double[] { circle.Radius, circle.Perimeter, circle.Area};
        }

        public static explicit operator Circle(double radius)
        {
            return new Circle(radius);
        }

        // Для задачи сортировки объектов
        public int CompareTo(Circle other)
        {
            return this.Area.CompareTo(other.Area);
        }
    }
}
