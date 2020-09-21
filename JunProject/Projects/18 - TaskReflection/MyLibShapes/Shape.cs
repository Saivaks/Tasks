using System;

namespace Shapes
{

    public abstract class Shape
    {
        public abstract double Area { get; protected set; }
        public abstract double Perimeter { get; protected set; }

        public abstract void AreaCalc();

        public abstract void PerimeterCalc();

        public virtual void ToPrint()
        {
            Console.WriteLine("Абстратная фигура");
        }
    }


    public class Circle : Shape
    {
        public override double Area { get; protected set; }
        public override double Perimeter { get; protected set; }
        public double Radius { get; protected set; }

        public Circle()
        {
            Radius = valueShape();
        }

        protected virtual double valueShape()
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
            Console.WriteLine($"Периметр круга: \t{Perimeter} \nПлощадь круга: \t{Area}");
        }
    }


    public class Phere : Circle
    {
        protected override double valueShape()
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
            Console.WriteLine($"Площадь поверхности шара: \t{this.Perimeter} \nОбъем шара: \t{Area} ");
        }
    }


    public class Rectangle : Shape
    {
        public override double Area { get; protected set; }
        public override double Perimeter { get; protected set; }

        public double Height { get; protected set; }
        public double Width { get; protected set; }

        private string CloseProperty { get; set; }

        public Rectangle()
        {
            var valueRectangle = valueShape();
            Width = valueRectangle[0];
            Height = valueRectangle[1];
            CloseProperty = "This is a private property";
        }

        protected virtual double[] valueShape()
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

        public double MethodWithParam(int count) 
        {
            this.AreaCalc();
            Console.WriteLine("Выполняется метод с параметром: Умножающий площадь прямоугольника на число однотипных объектов.");
            return this.Area * count;
        }
    }


    public class Coub : Rectangle
    {
        public double Depth { get; protected set; }

        protected override double[] valueShape()
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
