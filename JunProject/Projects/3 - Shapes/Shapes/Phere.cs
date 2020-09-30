using System;

namespace Shapes
{
    // Класс раширяющий класс Круг, и представляющий его в виде Сферы
    public class Phere : Circle
    {
        public Phere(double radius) : base(radius) { }

        // Метод отвечающий за создание экземляра объекта и корректный ввод радиуса сферы
        public new static Phere EnteringParameters()
        {
            double radius;
            do
            {
                Console.Write("Введите радиус сферы: R - ");
            } while (!Double.TryParse(Console.ReadLine(), out radius));

            return new Phere(radius);
        }

        protected override double AreaCalc()
        {
            return 4.0 / 3.0 * Math.PI * Math.Pow(Radius, 3);
        }

        protected override double PerimeterCalc()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override string ToString()
        {
            return $"Площадь поверхности шара: {this.Perimeter} \nОбъем шара: \t\t  {Area} ";
        }

        // Для задачи преобразования типов
        public static explicit operator double[] (Phere phere)
        {
            return new double[] { phere.Radius, phere.Perimeter, phere.Radius};
        }

        public static explicit operator Phere(double radius)
        {
            return new Phere(radius);
        }
    }
}
