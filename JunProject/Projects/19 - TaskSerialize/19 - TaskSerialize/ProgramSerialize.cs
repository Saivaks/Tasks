using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TaskSerialize
{
    public class ProgramSerialize
    {
        public static void Main()
        {
            Person person = new Person("Кей", "Альтос", 35, new Person("Кей", "Дач", 46, new Person("Keй", "Овальд", 57)));

            // Binary
            Console.WriteLine("Бинарная сериализация:");
            CreateBinarySerialize<Person>("people.dat", person);
            Person newPerson = CreateBinaryDeSerialize<Person>("people.dat");
            newPerson.ToPrint();

            //JSON
            //string jsonPerson = JsonSerializer.Serialize<Person>(person);
            //Console.WriteLine($"\nJSON:");
            //newPerson = JsonSerializer.Deserialize<Person>(jsonPerson);
            //newPerson.ToPrint();

            // XML
            Console.WriteLine("\nXML: ");
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                formatter.Serialize(fs, person);
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                newPerson = (Person)formatter.Deserialize(fs);
            newPerson.ToPrint();

            Console.WriteLine("\nКонец задачи.\n");
            Console.ReadKey();
        }

        // Бинарная сериализация и десиализация
        static void CreateBinarySerialize<T>(string address, T atrib)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(address, FileMode.OpenOrCreate))
                formatter.Serialize(fs, atrib);
        }

        static T CreateBinaryDeSerialize<T>(string address)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(address, FileMode.OpenOrCreate))
                return (T)formatter.Deserialize(fs);
        }
    }
}
