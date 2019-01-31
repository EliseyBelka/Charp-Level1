////ЗАДАНИЕ И АВТОР (класс используемый в задание№2)
////Реализуйте задачу 1 в виде статического класса StaticClass;
////а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
////б) * Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
////в)** Добавьте обработку ситуации отсутствия файла на диске.
////    АВТОР исполения Белканов Алексей

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lesspn4Task2
{
    internal static class StaticClass
    {
        /// <summary>
        /// Метод определяет пары в которых хотя бы один элемент кратен 3. Считает количество таких пар.
        /// </summary>
        /// <param name="array20"></param>
        /// <returns></returns>
        static public int SplitArray (int[] array)
        {
            //if (array.Length != 0 | array == null)
            try
            {
                int pairs = 0;
                for (int i = 1; i < array.Length; i++)
                    if (array[i - 1] % 3 == 0 | array[i] % 3 == 0)
                        pairs++;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nWant to see pairs of array elements (y/n)?");
                Console.ResetColor();

                if (Console.ReadKey().Key == ConsoleKey.Y)
                    PrintPairs(array);
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYour answer is regarded as a refusal.");
                    Console.ResetColor();
                }
                    

                return pairs;
            }
            catch //(Exception exception)//else
            {
                //Console.WriteLine(exception);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nArchive contains no data");
                Console.ResetColor();
                return 0;
            }
        }
        /// <summary>
        /// Выводит массив элементов
        /// </summary>
        /// <param name="array20"></param>
        static public void PrintArray(int[] array)
        {
            try//if (array.Length != 0 | array == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nThe array was filled with the following numbers:");
                Console.ResetColor();

                for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " ");
            }
            catch//else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nArchive contains no data");
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Выводит пары после проверки условия делимости на 3 элементов массива.
        /// </summary>
        /// <param name="array20"></param>
        static void PrintPairs(int[] array)
        {
            try//if (array.Length != 0 | array == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nThe number of pairs in which at least one element is a multiple of 3:");
                Console.ResetColor();

                for (int i = 1; i < array.Length; i++)
                    if (array[i - 1] % 3 == 0 | array[i] % 3 == 0)
                        Console.WriteLine($"{array[i - 1],6}   and { array[i],6}");
            }
            catch//else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nArchive contains no data");
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Считывает числа из файла. Возвращает массив чисел
        /// </summary>
        /// <param name="path"></param>
        static public int[] ArraFillFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                int correction=0;
                int[] SendArr = { };
                string Line;
                while ((Line = reader.ReadLine()) != null)
                {
                    //Console.WriteLine("\n"+Line);
                    string[] words = Line.Split(new char[] { ' ' });
                    Array.Resize(ref SendArr, SendArr.Length+words.Length);
                    for (int i = 0; i < words.Length; i++)
                        SendArr[correction + i] = int.Parse(words[i]);

                    correction += words.Length;
                }
                return SendArr;                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nFile not found in path - {path}");
                Console.ResetColor();
                return null;
            }
        }
    }
}
