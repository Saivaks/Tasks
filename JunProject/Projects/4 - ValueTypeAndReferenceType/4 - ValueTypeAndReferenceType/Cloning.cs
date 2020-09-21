using System;

namespace ValueTypeAndReferenceType
{
    public class Cloning
    {
        public static void Main()
        {
            Console.WriteLine("\nЗадача: Произвести глубокое копирование структуры.\nЕсть структура со следующими параметрами:");

            Product myProduct1 = new Product(5,75,125.33, ClassProduct.D, 'Q', new Provider ("Microsoft", new Company ("It's Address Microsoft")));
            myProduct1.ToPrint("Структура №1:");

            Product myProduct2 = new Product(0, 33, 22.8, ClassProduct.S, 'R', new Provider ("Google", new Company("It's Address Google")));
            myProduct2.ToPrint("Структура №2:");

            Console.ReadKey();
            Console.WriteLine("Произведем глубокое копирование структуры (Struct1->Struct2): ");
            myProduct2 = (Product)myProduct1.Clone();
            myProduct1.ToPrint("Структура №1:");
            myProduct2.ToPrint("Структура №2 (Копированная):");

            Console.ReadKey();
            Console.WriteLine("Изменяем свойства Count, Address и NameCompany во 2 объекте: ");
            myProduct2.Count = 333;
            myProduct2.MyProvider.company.NameCompany = "MailRu";
            myProduct2.MyProvider.Address = "It's Address MailRu";

            Console.WriteLine("\nПосле изменений: 1 объект \n");
            myProduct1.ToPrint("Структура №1:");
            Console.WriteLine("После изменений: 2 объект \n");
            myProduct2.ToPrint("Структура №2 (Измененная):");

            Console.WriteLine("Конец задачи.\n");
            Console.ReadKey();
        }
    }
}
