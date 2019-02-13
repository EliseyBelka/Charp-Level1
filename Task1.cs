//С помощью рефлексии выведите все свойства структуры DateTime
//Автор Алексей Белканов
using System;
using System.Reflection;
namespace cshLesson8
{
    class Task1
    {
        static void Main(string[] args)
        {
            int i=0;
            DateTime dateTime = new DateTime();
            Console.WriteLine("All properties of a class DataTime:");
            foreach (var prop in dateTime.GetType().GetProperties())
            {
                i++;
                Console.WriteLine("{0}.{1}",i, prop.Name);
            }
            Console.ReadKey();
        }
    }

}
