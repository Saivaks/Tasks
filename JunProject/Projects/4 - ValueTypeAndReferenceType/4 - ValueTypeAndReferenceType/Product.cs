using System;

namespace ValueTypeAndReferenceType
{
    // Структура описывающая Товар на складе, члены которой ве ValueType, в том числе содержащая внутри себя и структуру
    struct Product : ICloneable
    {
        public int Count { get; set; }                  // Количество товара на складе
        public decimal IdProduct { get; }               // ID товара
        public double Cost { get; }                     // Стоимость товара
        public bool Presence { get; }                   // наличие товара на складе
        public ClassProduct TypeClassProduct { get; }   // Тип товара
        public char Value { get; }                      // тут фантазия закончислась. Просто параметр char
        public Provider MyProvider;                     // Структура описывающая поставщика товара

        public Product(int count, decimal idProd, double cost, ClassProduct typePr, char value, Provider provider)
        {
            Count = count;
            IdProduct = idProd;
            Cost = cost;
            Presence = Count > 0 ? true : false;
            TypeClassProduct = typePr;
            Value = value;
            MyProvider = provider;
        }

        public void ToPrint(string str)
        {
            Console.WriteLine(str);
            Console.WriteLine($"Count     - {Count}");
            Console.WriteLine($"IdProduct - {IdProduct}");
            Console.WriteLine($"Cost      - {Cost}");
            Console.WriteLine($"Presence  - {Presence}");
            Console.WriteLine($"typeClassProduct - {TypeClassProduct}");
            Console.WriteLine($"Value     - {Value}");
            Console.WriteLine($"Поставщик: ");
            Console.WriteLine($"Name      - {MyProvider.company.NameCompany}");
            Console.WriteLine($"Address   - {MyProvider.Address}\n\n");
        }

        // Метод реализующий глубокое копирование структуры
        public object Clone()
        {
            return new Product(Count, IdProduct, Cost, TypeClassProduct, Value, (Provider)MyProvider.Clone());
        }
    }
}
