using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20___TaskRegular
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex;

            Console.WriteLine("Введите тестируемую строку:");
            string s = Console.ReadLine();

            MatchCollection numbers = new Regex(@"(\d+\s?)+(\.\d+)?").Matches(s); // 1, 1000, 1 000 000, 100.23
            ToPtint(numbers, "Введенная строка содержит следующие чиловые значения:");

            MatchCollection masParams = new Regex(@"\w+=[\d|\w]+").Matches(s); // http://ya.ru/api?r=1&x=23
            ToPtint(masParams, "Введенная строка содержит следующие параметры:");

            string removeDoubleSpase = new Regex(@"\s+").Replace(s, " ");
            Console.WriteLine($"Из введенной строки удалены двойные пробелы:\n{removeDoubleSpase}");

            MatchCollection telNumbers = new Regex(@"((\+\d{3})|0)?\(?\d{3}\)?\d{5}").Matches(s); //+37377767852, 77767852, 0(777)67852
            ToPtint(telNumbers, "Введенная строка содержит следующие телефонные номера:");

            Console.ReadLine(); 
        }

        static void ToPtint(MatchCollection coll, string s)
        {
            Console.WriteLine(s);
            foreach (var i in coll)
                Console.Write($"{i} |");
            Console.WriteLine();
        }
    }
}
