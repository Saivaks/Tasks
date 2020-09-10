using System;
using System.Collections.Generic;

// 3. Реализовать класс анализирующий поток чисел и если число отличается более чем x процентов выбрасывает событие
namespace _14___TaskEvents
{
    class Voltmeter
    {
        public List<double> Voltages { get; }
        public static double nominal = 220;
        public double Assumptions { get; }

        public Voltmeter(List<double> voltages, double assumptions)
        {
            Voltages = voltages;
            Assumptions = assumptions;
        }

        // Анализирует ряд чисел. При выходе за допустимое значение генерирует событие EventArgs
        public void CheckVolteges(Action<double, string> EventArgs)
        {
            double limit = nominal / 100 * Assumptions;
            foreach (double volt in Voltages)
            {
                if (Math.Abs(nominal-volt)>limit)
                    EventArgs?.Invoke(volt, "Число вышло за пределы допустимых значений.");
            }
        }
    }
}
