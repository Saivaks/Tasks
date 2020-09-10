using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4___ValueTypeAndReferenceType
{
    class Cloning
    {
        static void Main(string[] args)
        {
            Product myProduct1 = new Product(5,75,125.33, Product.ClassProduct.D, 'Q', "Microsoft", "It's Address Microsoft" );
            myProduct1.ToPrint();

            Product myProduct2 = new Product(0, 33, 22.8, Product.ClassProduct.S, 'R', "Google", "It's Address Google");
            myProduct2.ToPrint();

            Console.WriteLine("Глубокое копирование структуры: ");
            myProduct2 = (Product)myProduct1.Clone();
            myProduct1.ToPrint();
            myProduct2.ToPrint();

            Console.WriteLine("Изменяем свойства Count и Name во 2 объекте: ");
            myProduct2.Count = 333;
            myProduct2.MyProvider.company.NameCompany = "MailRu";

            Console.WriteLine("\n\nПосле изменений: 1 объект \n");
            myProduct1.ToPrint();
            Console.WriteLine("\n\nПосле изменений: 2 объект \n");
            myProduct2.ToPrint();

            Console.ReadKey();
        }
    }
}
