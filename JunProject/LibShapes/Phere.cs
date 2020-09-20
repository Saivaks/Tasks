using System;

namespace LibShapes
{
    // Класс раширяющий класс Круг, и представляющий его в виде Сферы
    public class Phere : Circle
    {
        public Phere() : base()
        { }

        protected override double EnteringParameters()
        {
            double radius;
            do
            {
                Console.Write("Введите радиус сферы: R - ");
            } while (!Double.TryParse(Console.ReadLine(), out radius));

            return radius;
        }

        protected override void AreaCalc()
        {
            Area = 4.0 / 3.0 * Math.PI * Math.Pow(Radius, 3);
        }

        protected override void PerimeterCalc()
        {
            Perimeter = 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override string ToString()
        {
            return $"Площадь поверхности шара: {this.Perimeter} \nОбъем шара: \t\t  {Area} ";
        }

        // Для задачи преобразования типов
        public Phere(double radius) : base(radius) { }

        public static explicit operator double[] (Phere phere)
        {
            return new double[] { phere.Radius, phere.Perimeter, phere.Radius };
        }

        public static explicit operator Phere(double radius)
        {
            return new Phere(radius);
        }
    }
}
