////ЗАДАНИЕ И АВТОР
////Дан целочисленный  массив из 20 элементов.
////Элементы массива  могут принимать  целые значения  от –10 000 до 10 000 включительно.
////Заполнить случайными числами.
////Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
////В данной задаче под парой подразумевается два подряд идущих элемента массива.
////Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
////    АВТОР исполения Белканов Алексей

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lessons4Task1
{
    internal class Task1
    {   /// <summary>
        ///Великая пауза))) 
        /// </summary>
        private static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        /// <summary>
        /// Генератор случаных чисел.
        /// </summary>
        /// <returns></returns>
        private static int RandNumGen()
        {
            Random Rng = new Random();
            int RundNum = Rng.Next(-10000,10001);   //т.к. включительно 10000
            Thread.Sleep(10);                       //!!!учет особенности генератора псевдослучайных чисел!!!
            return RundNum;
        }

        private static void Main(string[] args)
        {   int pairs=0;
            int[] array20 = new int[20];
            Console.WriteLine($"The array was filled with the following numbers:");
            for (int i = 0; i < array20.Length; i++)
            {
              array20[i] = RandNumGen();
                
                Console.Write(array20[i]+" ");
            }

            Console.WriteLine($"\nPairs of numbers satisfying the condition:");

            for (int i = 1; i < array20.Length; i++)
                if (array20[i - 1] % 3 == 0 | array20[i] % 3 == 0)
                {
                    Console.WriteLine($"{array20[i - 1],6}   and { array20[i],6}");
                    pairs++;
                }
            
            Console.WriteLine($"The number of pairs of numbers: {pairs}");
            Pause();
        }
    }
}
