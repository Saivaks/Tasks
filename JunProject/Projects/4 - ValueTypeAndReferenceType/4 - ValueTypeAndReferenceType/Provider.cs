using System;

namespace ValueTypeAndReferenceType
{
    // Структура описывающая поставщика 
    internal struct Provider : ICloneable
    {
        internal string Address { get; set; } // Адрес поставщика
        internal Company company; // Класс описывающий компанию поставщика товара

        internal Provider(string add, Company comp)
        {
            Address = add;
            company = comp;
        }

        public object Clone()
        {
            return new Provider(Address, (Company)company.Clone());
        }
    }
}
