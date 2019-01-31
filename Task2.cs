////ЗАДАНИЕ И АВТОР
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
using System.Threading;

namespace Lesspn4Task2
{
    internal class Task2
    {
        /// <summary>
        ///Великая пауза))) 
        /// </summary>
        private static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        /// <summary>
        /// Генератор псевдослучайных случаных чисел.
        /// </summary>
        /// <returns></returns>
        private static int RandNumGen()
        {
            Random Rng = new Random();
            int RundNum = Rng.Next(-10000, 10001);   //т.к. включительно 10000
            Thread.Sleep(10);                       //!!!учет особенности генератора псевдослучайных чисел!!!
            return RundNum;
        }

        private static void Main(string[] args)
        {
            int[] arrayN = {};
           

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Do you want to fill the array with random numbers (y/n)? ");
            Console.ResetColor();

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Array.Resize(ref arrayN, 20);
                for (int i = 0; i < 20; i++) arrayN[i] = RandNumGen();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nPrint the storage location of the data file\nPath\\name.format:");
                Console.ResetColor();
                string path = Console.ReadLine();
                arrayN = StaticClass.ArraFillFile(path);

            }

            //StaticClass.PrintArray(arrayN);
            Console.WriteLine($"Number of pairs: {StaticClass.SplitArray(arrayN)}");
            
            Pause();
        }
       
    }
}
