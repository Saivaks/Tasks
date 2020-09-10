using System;

namespace Shapes
{
    // Абстрактный класс фигур, содержащий такие свойства как периметр и лощадь, а также минимальный необходимый набор методов.
    abstract class Shape
    {
        public abstract double Area { get; protected set; }
        public abstract double Perimeter { get; protected set; }

        // Метод отвечающий за вычисление площади фигуры
        public abstract void AreaCalc();

        // Метод отвечающий за вычисление периметра фигуры
        public abstract void PerimeterCalc();

        // Вывод параметров фигуры на экран консоли
        public virtual void ToPrint()
        {
            Console.WriteLine("Абстратная фигура");
        }
    }

    // Класс описывающий геометрическую фигуру как Круг.
    class Circle : Shape
    {
        public override double Area { get; protected set; }
        public override double Perimeter { get; protected set; }
        public double Radius { get; protected set; }

        public Circle()
        {
            Radius = EnteringParameters();
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

        public override void AreaCalc()
        {
            Area = Math.PI * Radius * Radius;
        }

        public override void PerimeterCalc()
        {
            Perimeter = 2 * Math.PI * Radius;
        }

        public override void ToPrint()
        {
            this.AreaCalc();
            this.PerimeterCalc();
            Console.WriteLine($"Периметр круга: {Perimeter} \nПлощадь круга: \t{Area}");
        }
    }

    // Класс раширяющий класс Круг, и представляющий его в виде Сферы
    class Phere : Circle
    {
        protected override double EnteringParameters()
        {
            double radius;
            do
            {
                Console.Write("Введите радиус сферы: R - ");
            } while (!Double.TryParse(Console.ReadLine(), out radius));

            return radius;
        }

        public override void AreaCalc()
        {
            Area = 4.0 / 3.0 * Math.PI * Math.Pow(Radius, 3);
        }

        public override void PerimeterCalc()
        {
            Perimeter = 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override void ToPrint()
        {
            this.AreaCalc();
            this.PerimeterCalc();
            Console.WriteLine($"Площадь поверхности шара: {this.Perimeter} \nОбъем шара: \t\t  {Area} ");
        }
    }

    // Класс описывающий геометрическую фигуру как Прямоугольник.
    class Rectangle : Shape
    {
        public override double Area { get; protected set; }
        public override double Perimeter { get; protected set; }

        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public Rectangle()
        {
            var valueRectangle = EnteringParameters();
            Width = valueRectangle[0];
            Height = valueRectangle[1];
        }

        // Метод отвечающий за корректный ввод сторон Прямоугольника
        protected virtual double[] EnteringParameters()
        {
            var value = new double[2];
            string[] sideRectangle;
            do
            {
                Console.WriteLine("Введите длин сторон прямоугольника через пробел:");
                sideRectangle = Console.ReadLine().Split(new char[] { ' ' });
            } while (!(sideRectangle.Length == 2 && Double.TryParse(sideRectangle[0], out value[0]) && Double.TryParse(sideRectangle[1], out value[1])));

            return value;
        }

        public override void AreaCalc()
        {
            Area = Width * Height;
        }

        public override void PerimeterCalc()
        {
            Perimeter = 2 * (Height + Width);
        }

        public override void ToPrint()
        {
            this.AreaCalc();
            this.PerimeterCalc();
            Console.WriteLine($"Периметр прямоугольника: \t{Perimeter} \nПлощадь прямоугольника: \t{Area}");
        }
    }

    // Класс раширяющий класс Прямоугольник, и представляющий его в виде Куба
    class Coub : Rectangle
    {
        public double Depth { get; protected set; }

        protected override double[] EnteringParameters()
        {
            var value = new double[3];
            string[] sideRectangle;
            do
            {
                Console.WriteLine("Введите длин сторон прямоугольного параллелепипеда через пробел:");
                sideRectangle = Console.ReadLine().Split(new char[] { ' ' });
            } while (!(sideRectangle.Length == 3 && Double.TryParse(sideRectangle[0], out value[0]) && Double.TryParse(sideRectangle[1], out value[1]) && Double.TryParse(sideRectangle[2], out value[2])));

            Depth = value[2];
            return value;
        }

        public override void AreaCalc()
        {
            Area = Depth * Width * Height;
        }

        public override void PerimeterCalc()
        {
            Perimeter = 2 * (Depth * Height + Depth * Width + Height * Width);
        }

        public override void ToPrint()
        {
            this.AreaCalc();
            this.PerimeterCalc();
            Console.WriteLine($"Периметр куба: \t{Perimeter} \nПлощадь куба: \t{Area}");
        }
    }
}
