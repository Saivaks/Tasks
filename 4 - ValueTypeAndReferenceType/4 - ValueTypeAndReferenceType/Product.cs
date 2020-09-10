using System;

namespace _4___ValueTypeAndReferenceType
{
    // Структура описывающая Товар на складе, члены которой ве ValueType, в том числе содержащая внутри себя и структуру
    struct Product: ICloneable
    {
        public int Count { get; set; } // Количество товара на складе
        public decimal IdProduct { get; } // ID товара
        public double Cost { get; } // Стоимость товара
        public bool Presence { get; } // наличие товара на складе
        public ClassProduct TypeClassProduct { get; } // Тип товара
        public char Value { get; } // тут фантазия закончислась. Просто параметр char
        public Provider MyProvider { get; set; } // Структура описывающая поставщика товара


        public Product(int count, decimal idProd, double cost, ClassProduct typePr, char value, string name, string add)
        {
            Count = count;
            IdProduct = idProd;
            Cost = cost;
            Presence = Count > 0 ? true : false;
            TypeClassProduct = typePr;
            Value = value;
            MyProvider = new Provider(add, name);
        }

        public void ToPrint()
        {
            Console.WriteLine($"Count - {Count}");
            Console.WriteLine($"IdProduct - {IdProduct}");
            Console.WriteLine($"Const - {Cost}");
            Console.WriteLine($"Presence - {Presence}");
            Console.WriteLine($"typeClassProduct - {TypeClassProduct}");
            Console.WriteLine($"Value - {Value}");
            Console.WriteLine($"Поставщик: ");
            Console.WriteLine($"Name - {MyProvider.company.NameCompany}");
            Console.WriteLine($"Address - {MyProvider.address}\n\n");
        }

        // Метод реализующий глубокое копирование структуры
        public object Clone()
        {
            return new Product(Count, IdProduct, Cost, TypeClassProduct, Value, MyProvider.company.NameCompany, MyProvider.address);
        }

        // Структура описывающая поставщика 
        public struct Provider
        {
            public string address; // Адрес поставщика
            public Company company; // Класс описывающий компанию поставщика товара

            public Provider(string add, string name)
            {
                address = add;
                company = new Company(name);
            }
        }

        public enum ClassProduct : byte
        {
            S = 1,
            A,
            B,
            C,
            D,
            E,
            F
        }
    }

    // класс описывающий компанию. Используется для внесения в структуру содержащую ссылочный тип данных
    class Company
    {
        public string NameCompany { get; set; }

        public Company(string name)
        {
            NameCompany = name;
        }
    }
}
