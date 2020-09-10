using System;
using Shapes;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18___TaskReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type myType = Type.GetType("Shapes.Rectangle, MyLibShapes", true, false);

            // Создание экземпляра объекта
            object shapeRectangle = Activator.CreateInstance(myType);

            // Получение метода c параметром
            MethodInfo methodShape = myType.GetMethod("MethodWithParam");

            // Вызов метода с параметрами
            object result = methodShape?.Invoke(shapeRectangle, new object[] { 3 }); 
            Console.WriteLine(result);

            // Проведение рефлексии типа Rectangle
            CreateReflection(shapeRectangle); 

            Console.ReadLine();
        }

        // Метод объединяющий все методы для рефлексии объекта obj
        static void CreateReflection(Object obj)
        {
            Console.WriteLine($"\n\nПроизведем рефлексию:");
            ParseField(obj);
            ParseProperty(obj);
            ParseInterfase(obj.GetType());
            ParseConstr(obj.GetType());
            ParseMethod(obj.GetType());
        }

        // Выводим на экран все поля объекта obj
        static void ParseField(Object obj)
        {
            Console.WriteLine("\nПоля:");
            Type value = obj.GetType();
            foreach (FieldInfo field in value.GetFields())
                Console.WriteLine($"{field.FieldType.Name} {field.Name} - {field.GetValue(obj)}");
        }

        // Выводим на экран все свойства объекта obj
        static void ParseProperty(Object obj)
        {
            Console.WriteLine("\nСвойства:");
            Type value = obj.GetType();
            foreach (PropertyInfo propery in value.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                Console.WriteLine($"{propery.PropertyType.Name} {propery.Name} - {propery.GetValue(obj)}");
        }

        // Выводим на экран все реализованные интерфейсы объекта obj
        static void ParseInterfase(Type value)
        {
            Console.WriteLine("\nРеализованные интерфейсы:");
            foreach (Type i in value.GetInterfaces())
                Console.WriteLine(i.Name);
        }

        // Выводим на экран все конструкторы объекта obj
        static void ParseConstr(Type value)
        {
            Console.WriteLine("\nКонструкторы:");
            foreach (ConstructorInfo constr in value.GetConstructors())
            {
                Console.Write($"{value.Name}  (");
                ParameterInfo[] parameters = constr.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length)
                        Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }

        // Выводим на экран все методы объекта obj
        static void ParseMethod(Type value)
        {
            Console.WriteLine("\nМетоды:");
            if (value != null)
            {
                foreach (MethodInfo method in value.GetMethods(BindingFlags.DeclaredOnly| BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    string modificator = "";
                    if (method.IsStatic)
                        modificator += "static";
                    if (method.IsVirtual)
                        modificator += "virtual";
                    if (method.IsPrivate)
                        modificator += " private";
                    if (method.IsPublic)
                        modificator += " public";
                    Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");

                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                        if (i + 1 < parameters.Length)
                            Console.Write(", ");
                    }
                    Console.WriteLine(")");
                }
            }
        }
    }
}
