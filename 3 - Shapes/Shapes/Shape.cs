using System;

namespace Shapes
{
    // Абстрактный класс фигур, содержащий такие свойства как периметр и лощадь, а также минимальный необходимый набор методов.
    public abstract class Shape
    {
        // чтобы в дальнейшем, если понадобится, можно было бы легко их сделать полноценными свойствоми (в данной задаче это не потребовалось)  или автоматическим, в зависимости от потребностей. 
        public double Area { get { return AreaCalc(); }}
        public double Perimeter { get { return PerimeterCalc();} }

        // Метод отвечающий за вычисление площади фигуры
        protected abstract double AreaCalc();

        // Метод отвечающий за вычисление периметра фигуры
        protected abstract double PerimeterCalc();

        // Вывод параметров фигуры на экран консоли 
        public override string ToString()
        {
            return "Абстрактная фигура";
        }
    }
}
