using System;
using System.Reflection.Emit;

namespace Shapes
{
    class AreaCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение для рассчета Периметра (P) и Площади (S) геометрических фигур.");
            bool flag = true;
            Shape shape = null;
            do
            {
                Console.WriteLine(@"ВЫберете одну из следующих опций:
                                    1 - Произвести рассчет круга
                                    2 - приозвести рассчет сферы
                                    3 - Произвести рассчет прямогульника
                                    4 - Произвести рассчет прямоугольного параллелепиеда
                                    5 - Закончить работу в приложении");

                switch (Console.ReadLine())
                {
                    case "1":
                        shape = new Circle();
                        goto case "Print";
                    case "2":
                        shape = new Phere();
                        goto case "Print";
                    case "3":
                        shape = new Rectangle();
                        goto case "Print";
                    case "4":
                        shape = new Coub();
                        goto case "Print";
                    case "5":
                        flag = false;
                        break;
                    case "Print":
                        shape?.ToPrint();
                        break;
                    default:
                        shape = null;
                        Console.WriteLine("Ошибка при вводе.");
                        break;
                }
            } while (flag);
        }
    }
}
