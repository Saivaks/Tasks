using System;
using System.Collections.Generic;

// 3. Реализовать класс анализирующий поток чисел и если число отличается более чем x процентов выбрасывает событие
namespace TaskEvents
{
    internal class Voltmeter
    {
        internal List<double> Voltages { get; }
        internal static double nominal = 220;
        internal double Assumptions { get; }

        internal Voltmeter(List<double> voltages, double assumptions)
        {
            Voltages = voltages;
            Assumptions = assumptions;
        }

        // Анализирует ряд чисел. При выходе за допустимое значение генерирует событие EventArgs
        internal void CheckVolteges(Action<double, string> EventArgs)
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
