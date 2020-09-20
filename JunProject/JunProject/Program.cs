using System;

namespace JunProject
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool flag = true;
            Console.WriteLine("Приложение для тестирования решенных задач.");
            do
            {
                Console.WriteLine(@"Выберете номер тестируемой задачи:
                1  - Shapes,
                2  - Value Type and Reference Type,
                3  - Type Conversion,
                4  - Enumerable,
                5  - Linq,
                6  - Comparable,
                7  - Equals,
                8  - List or Dictionary,
                9  - Generic Member,
                10 - Events,
                11 - Extentions,
                12 - Reflection,
                13 - Serialize, 
                14 - Regular,
                15 - Thread mas,
                16 - Thread run,
                20 - Закончить работу в приложении.");

                // Если бы необходимо было передавать методы в качестве аргументов, можно былобы исользовать делегат 
                switch (Console.ReadLine())
                {
                    case "1":
                        Shapes.AreaCalculator.Main();
                        break;
                    case "2":
                        ValueTypeAndReferenceType.Cloning.Main();
                        break;
                    case "3":
                        TypeConversion.Conversion.Main();
                        break;
                    case "4":
                        TaskEnumerable.Enumeration.Main();
                        break;
                    case "5":
                        TaskLinq.LinqExpressions.Main();
                        break;
                    case "6":
                        TaskComparable.SortShapes.Main();
                        break;
                    case "7":
                        TaskEquals.EqualsOrGetHashCode.Main();
                        break;
                    case "8":
                        TaskListOrDictionary.TaskDictionary.Main();
                        break;
                    case "9":
                        TaskGenericMember.ProgramGenericMember.Main();
                        break;
                    case "10":
                        TaskEvents.ProgramEvents.Main();
                        break;
                    case "11":
                        TaskExtentions.ProgramExtentions.Main();
                        break;
                    case "12":
                        TaskReflection.ProgramReflection.Main();
                        break;
                    case "13":
                        TaskSerialize.ProgramSerialize.Main();
                        break;
                    case "14":
                        TaskRegular.ProgramRegular.Main();
                        break;
                    case "15":
                        break;
                    case "20":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введено некорректное значение.\n");
                        break;
                }
            } while (flag);

            Console.WriteLine("Конец работы в приложении.");
            Console.ReadKey();
        }
    }
}
