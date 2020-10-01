using System;
using Shapes;

namespace TypeConversion
{
    public class Conversion
    {
        public static void Main()
        {
            Console.WriteLine("Задача: Реализовать явное и неявное преобразование типов.");
            bool flag = true;
            do
            {
                Console.WriteLine(@"Выберете опцию:
                                    1 - Стандартный запуск (Вызоыв базового метода - Person);
                                    2 - Преобразование типов фигур (Проект Shapes);
                                    3 - Закончить работу.");

                switch (Console.ReadLine())
                {
                    case "1":
                        RunMethodPerson();
                        break;
                    case "2":
                        RunMethodShapes();
                        break;
                    case "3":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода.");
                        break;
                }

            } while (flag);

            Console.WriteLine("Завершение работы с преобразованием типов.");
            Console.ReadKey();
        }

        private static void RunMethodPerson()
        {
            PersonName peson1 = new PersonName("Пименов", "Владимир");
            // Неявное преобразование
            string myName = peson1;
            Console.WriteLine($"неявное преобразование Person -> string: {myName}\n");

            // Явное преобразование
            PersonName person2 = (PersonName)myName;
            Console.WriteLine("Явное преобразование string -> Person:");
            Console.WriteLine(person2.ToString());

            Console.WriteLine("\nПользовательский ввод. Введите фамилию и имя:");
            string myName2 = Console.ReadLine();
            Console.WriteLine("Явное преобразование пользовательского ввода string -> Person:");
            PersonName person3 = (PersonName)myName2;
            Console.WriteLine(person3);

            // Equals Or ==
            Console.WriteLine($"\nExplicit - {peson1.Equals(myName)}"); // Для корректной работы метода, нужна его пергрузка в Person
            Console.WriteLine($"==        - {peson1 == myName}");       // Неявное преобразование с последующим сравнением
        }


        private static void RunMethodShapes()
        {
            Console.WriteLine("Задача: Использовать общие классы с проектом Shapes.");

            Console.WriteLine("1. Произведем преобразование типов: Coub -> Rectangle. Для этого создадим объект куб:");
            Coub coub = Coub.EnteringParameters();
            Rectangle rect = coub; 
            // Если нам надо получить метод rect.ToString() соотвествующий классу Rectangle, то необходимо исопльзовать сокрытие методов
            Console.WriteLine($"Получим объект Rectangle со следующими параметрами: \nHeight - {rect.Height}\nWidth - {rect.Width}\n{rect.ToString()}\n"); 

            Console.WriteLine("2. Произведем преобразование типов: Phere -> Circle. Для этого создадим объект шар:");
            Phere phere = Phere.EnteringParameters();
            Circle circle = phere;
            Console.WriteLine($"Получим объект Circle со следующими параметрами: \nRadius - {circle.Radius}\n{circle.ToString()}\n");

            Console.WriteLine("3. Произведем неявное преобразование типов: Circle -> double[]. Для этого создадим объект круг:");
            Circle circle2 = Circle.EnteringParameters();
            double[] mas = circle2;
            Console.WriteLine($"Получим массив со следующими параметрами: [Radius- {mas[0]}, Perimeter - {mas[1]}, Area - {mas[2]}]\n");

            Console.WriteLine("4. Произведем неявное преобразование типов: Phere -> double[]. Для этого создадим объект шар:");
            Phere phere2 = Phere.EnteringParameters();
            double[] mas2 = phere2;
            Console.WriteLine($"Получим массив со следующими параметрами: [Radius- {mas2[0]}, Perimeter - {mas2[1]}, Area - {mas2[2]}]\n");

            Console.WriteLine("5. Произведем явное преобразование типов: double (value = 3.4) -> Circle.");
            Circle circle3 = (Circle)3.4;
            Console.WriteLine($"Radius - {circle3.Radius}\n{circle3.ToString()}\n");
            Console.ReadKey();

            Console.WriteLine("6. Произведем явное преобразование типов: double (value = 3.7) -> Phere.");
            Phere phere3 = (Phere)3.7;
            Console.WriteLine($"Radius - {phere3.Radius}\n{phere3.ToString()}\n");
            Console.ReadKey();
        }
    }   
}
