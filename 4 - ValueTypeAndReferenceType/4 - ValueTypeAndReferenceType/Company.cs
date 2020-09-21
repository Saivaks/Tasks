using System;

namespace ValueTypeAndReferenceType
{
    // класс описывающий компанию. Используется для внесения в структуру содержащую ссылочный тип данных
    internal class Company: ICloneable
    {
        internal string NameCompany { get; set; }

        internal Company(string name)
        {
            NameCompany = name;
        }

        public object Clone()
        {
            return new Company(this.NameCompany);
        }
    }
}
