using System;
using LibShapes;
using System.Reflection;

namespace TaskReflection
{
    public class ProgramReflection
    {
        public static void Main()
        {
            Console.WriteLine("Задача: Провести разбор класса.");
            Type myType = typeof(Rectangle);

            object shapeRectangle = Activator.CreateInstance(myType); // Создание экземпляра объекта

            MethodInfo methodShape = myType.GetMethod("MethodWithParam"); // Получение метода c параметром

            object result = methodShape?.Invoke(shapeRectangle, new object[] { 3 }); // Вызов метода с параметрами
            Console.WriteLine(result);

            TypeReflection(shapeRectangle); // Проведение рефлексии типа Rectangle

            Console.ReadLine();
        }

        private static void TypeReflection(Object obj)
        {
            Console.WriteLine($"\n\nПроизведем рефлексию:");
            ParseField(obj);
            ParseProperty(obj);
            ParseInterfase(obj.GetType());
            ParseConstr(obj.GetType());
            ParseMethod(obj.GetType());
        }

        private static void ParseField(Object obj)
        {
            Console.WriteLine("\nПоля:");
            Type value = obj.GetType();
            foreach (FieldInfo field in value.GetFields())
                Console.WriteLine($"{field.FieldType.Name} {field.Name} - {field.GetValue(obj)}");
        }

        private static void ParseProperty(Object obj)
        {
            Console.WriteLine("\nСвойства:");
            Type value = obj.GetType();
            foreach (PropertyInfo propery in value.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                Console.WriteLine($"{propery.PropertyType.Name} {propery.Name} - {propery.GetValue(obj)}");
        }

        private static void ParseInterfase(Type value)
        {
            Console.WriteLine("\nРеализованные интерфейсы:");
            foreach (Type i in value.GetInterfaces())
                Console.WriteLine(i.Name);
        }

        private static void ParseConstr(Type value)
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

        private static void ParseMethod(Type value)
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
