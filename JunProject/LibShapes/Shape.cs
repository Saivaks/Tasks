using System;

namespace LibShapes
{
    // Абстрактный класс фигур, содержащий такие свойства как периметр и лощадь, а также минимальный необходимый набор методов.
    public abstract class Shape
    {
        // Зачем Area \ Perimeter были абстрактными? Просто в базом классе установил асбрактные свойства отвечающие за данные параметры, 
        // чтобы в дальнейшем, если понадобится, можно было бы легко их сделать полноценными свойствоми (в данной задаче это не потребовалось)  или автоматическим, в зависимости от потребностей. 
        public double Area { get; protected set; }
        public double Perimeter { get; protected set; }

        // Метод отвечающий за вычисление площади фигуры
        protected abstract void AreaCalc();

        // Метод отвечающий за вычисление периметра фигуры
        protected abstract void PerimeterCalc();

        // Вывод параметров фигуры на экран консоли 
        public override string ToString()
        {
            return "Абстрактная фигура";
        }
    }
}
