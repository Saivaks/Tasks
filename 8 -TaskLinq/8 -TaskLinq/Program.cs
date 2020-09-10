using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8__TaskLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем массив параметров humans, содержащий 100 объектов Human
            Human[] humans = GenericObjectHumans();

            // Выводим массив араметров на экран
            foreach (Human human in humans)
                human.ToPrint();

            // Далее идет выолнение поставленной задачи. 
            // Она написана в главном методе, т.к. по сути данный код выполняется единожды и его можно было описать как вызов ряда методов типа: void MethodTask(Human[] humans);

            // Создание фильтра с Where
            Console.WriteLine("\nВЫборка всех совершеннолетних людей имя которых оканчивается на \'Й\':");
            {
                var humansMajority = from human in humans
                    where human.Majority == true && human.FirstName[human.FirstName.Length - 1] == 'й'
                    select human;

                foreach (var human in humansMajority)
                {
                    Console.WriteLine($"{human.FirstName} {human.Age}");
                }
            }

            // Сортировака: orderby
            Console.WriteLine("\nСортировка людей по совершненнолетию и имени:"); 
            {
                var humanSort = from human in humans
                    orderby human.Majority, human.FirstName
                    select human;

                foreach (var human in humanSort)
                {
                    Console.WriteLine($"{human.FirstName} {human.Age}");
                }
            }

            // Использование Sum, на чисовых значениях
            Console.WriteLine("\nСредний возраст людей в выборке: "); 
            {
                double averageAge_Sum = humans.Sum(x => x.Age)/humans.Length;
                double averageAge_Average = humans.Average(x => x.Age);
                Console.WriteLine($"Средний возраст: (Sum) {averageAge_Average} | (Average) {averageAge_Average}");
            }

            // Нахождение Min | Max значений параметров
            Console.WriteLine("\nМинимальный и максимальный возраст в выборке:"); 
            {
                Console.WriteLine($"Min Age = {humans.Min(x=>x.Age)} \nMax Age = {humans.Max(x=>x.Age)}");
            }

            // Группировка объектов (group by) по каким либо  признакам
            Console.WriteLine("\nПроизведем группировку объектов выборки по параметру FirstName: ");
            {
                var humanGroup = humans.GroupBy(x => x.FirstName)
                    .Select(x => new {Name = x.Key, Count = x.Count(), Humans = x.Select(w => w)});

                foreach (var dict in humanGroup)
                {
                    Console.WriteLine($"\n{dict.Name} {dict.Count}:");
                    foreach (Human human in dict.Humans)
                        Console.WriteLine($"\t{human.FirstName} {human.Age}");
                }
            }

            // Проверка массива на соответствие условий All | Any
            Console.WriteLine("\nПроверим выборку на высказывания:"); 
            {
                Console.WriteLine($"У всех людей возраст в выборке > 1 {humans.All(x=>x.Age>1)}");
                Console.WriteLine($"У всех людей в выбрке имя начинается с \'A\': {humans.All(x=>x.FirstName[0] == 'А')}");
                Console.WriteLine($"Существует такой человек, чей возраст составляет 66 лет: {humans.Any(x=>x.Age == 66)}");
                Console.WriteLine($"Существует такой человек, который родился 1 Января: {humans.Any(x=>x.DateOfBirth.Month ==1 && x.DateOfBirth.Day ==1)}");
            }

            Console.ReadKey();
        }

        // Метод генерирующий и возвращающий массив содержащий 100 объектов Human
        public static Human[] GenericObjectHumans ()
        {
            Random rng = new Random();
            Human[] humans = new Human[100];
            string Names =
                "Август,Августин,Авраам,Аврора,Агата,Агафон,Агнесса,Агния,Ада,Аделаида,Аделина,Адонис,Акайо,Акулина,Алан,Алевтина,Александр,Александра,Алексей,Алена,Алина,Алиса,Алла,Алсу,Альберт,Альбина,Альфия,Альфред,Амалия,Амелия,Анастасий,Анастасия,Анатолий,Ангелина,Андрей,Анжела,Анжелика,Анисий,Анна,Антон,Антонина,Анфиса,Аполлинарий,Аполлон,Ариадна,Арина,Аристарх,Аркадий,Арсен,Арсений,Артем,Артемий,Артур,Архип,Ася";
            string[] nameEvents = Names.Split(new char[] {','});
            for (int i = 0; i < 100; i++)
            {
                humans[i] = new Human(nameEvents[rng.Next(0,nameEvents.Length)],new DateTime(rng.Next(1950,2020),rng.Next(1,12),rng.Next(1,28)));
            }

            return humans;
        }
    }
}
