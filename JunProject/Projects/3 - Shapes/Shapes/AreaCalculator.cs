using System;
using System.Reflection.Emit;

namespace Shapes
{
    public class AreaCalculator
    {
        public static void Main()
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
                                    4 - Произвести рассчет прямоугольного параллелепиедаs
                                    5 - Закончить работу в приложении");

                switch (Console.ReadLine())
                {
                    case "1":
                        shape = Circle.EnteringParameters();
                        goto case "Print";
                    case "2":
                        shape = Phere.EnteringParameters(); ;
                        goto case "Print";
                    case "3":
                        shape = Rectangle.EnteringParameters();
                        goto case "Print";
                    case "4":
                        shape = Coub.EnteringParameters();
                        goto case "Print";
                    case "5":
                        flag = false;
                        break;
                    case "Print":
                        Console.WriteLine(shape?.ToString());
                        break;
                    default:
                        Console.WriteLine("Ошибка при вводе.");
                        break;
                }
            } while (flag);

            Console.WriteLine("Завершение работы с фигурами.");
            Console.ReadKey();
        }
    }
}
