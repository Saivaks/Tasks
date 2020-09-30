using System;
using System.Data;
using System.Linq;

namespace TaskLinq
{
    public class LinqExpressions
    {
        public static void Main()
        {
            Console.WriteLine("\nОписать произвольный тип со свойствами разных типов (строка, число, дата, bool). \nГенерировать 100 объектов с произвольными значениями. Сделать выборки.");
            // Создаем массив параметров humans, содержащий 100 объектов Human
            Human[] humans = GenericObjectHumans();

            Console.WriteLine("Сгенерируем следующие объекты:");
            Console.ReadKey();

            // Выводим массив араметров на экран
            foreach (Human human in humans)
                Console.WriteLine(human.ToString());

            // Создание фильтра с Where
            FilterUseWhere(humans, 'й');
            Console.ReadKey(); 

            // Сортировака: orderby
            FilterUseOrderBy(humans);
            Console.ReadKey();

            // Использование Sum, на чисовых значениях
            Console.WriteLine("\nСредний возраст людей в выборке: "); 
            {
                Console.WriteLine($"Средний возраст: (Sum) { humans.Average( x => x.Age) }");
                Console.ReadKey();
            }

            // Нахождение Min | Max значений параметров
            Console.WriteLine("\nМинимальный и максимальный возраст в выборке:"); 
            {
                Console.WriteLine($"Min Age = { humans.Min(x => x.Age) } \nMax Age = { humans.Max( x => x.Age) }");
                Console.ReadKey();
            }

            // Группировка объектов (group by) по каким либо  признакам
            Console.WriteLine("\nПроизведем группировку объектов выборки по параметру FirstName: ");
            {
                Console.ReadKey();
                var humanGroup = humans
                    .GroupBy(x => x.FirstName)
                    .Select(x => new { Name = x.Key, Count = x.Count(), Humans = x.Select(w => w) });

                foreach (var dict in humanGroup)
                {
                    Console.WriteLine($"\n{dict.Name} {dict.Count}:");
                    foreach (Human human in dict.Humans)
                        Console.WriteLine($"\t{human.FirstName} {human.Age}");
                }

                Console.ReadKey();
            }

            // Проверка массива на соответствие условий All | Any
            Console.WriteLine("\nПроверим выборку на высказывания:"); 
            {
                // All
                Console.ReadKey();
                Console.WriteLine($"У всех людей возраст в выборке > 1 { humans.All(x => x.Age > 1) }");
                Console.WriteLine($"У всех людей в выбрке имя начинается с \'A\': { humans.All(x => x.FirstName[0] == 'А') }");
                // Any
                Console.ReadKey();
                Console.WriteLine($"Существует такой человек, чей возраст составляет 66 лет: { humans.Any(x => x.Age == 66) }");
                Console.WriteLine($"Существует такой человек, который родился 1 Января: { humans.Any(x => x.DateOfBirth.Month == 1 && x.DateOfBirth.Day == 1) }");
                Console.ReadKey();
            }

            Console.WriteLine("\nКонец задачи.\n");
            Console.ReadKey();
        }

        // Метод находящий и выводящий имена заканчивающиеся на заданую букву
        private static void FilterUseWhere(Human[] humans, char letter)
        {
            Console.WriteLine($"\nВыборка всех совершеннолетних людей имя которых оканчивается на \'{letter}\':");
            Console.ReadKey();

            // LINQ выражение в точечной нотации
            var humansMajorityDotNotation = humans
                .Where(x => x.Majority == true && x.FirstName[x.FirstName.Length - 1] == letter)
                .Select(x=>x);

            foreach (var human in humansMajorityDotNotation)
                Console.WriteLine(human.ToString());
        }

        // Метод сортирующий людей сначала по совершенолетию, а затем по имени
        private static void FilterUseOrderBy(Human[] humans)
        {
            Console.WriteLine("\nСортировка людей по совершненнолетию и имени:");
            Console.ReadKey();

            // LINQ выражение в точечной нотации
            var humanSortDotNotation = humans
                .OrderBy(x => x.Majority)
                .ThenBy(x => x.FirstName)
                .Select(x => x);

            foreach (var human in humanSortDotNotation)
                Console.WriteLine($"{human.FirstName} {human.Age}");
        }

        // Метод генерирующий и возвращающий массив содержащий 100 объектов Human
        internal static Human[] GenericObjectHumans()
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
