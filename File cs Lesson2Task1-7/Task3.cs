using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task3
{
    class Task3
    {
        //метод опрделяющий паузу по окончанию программы
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        private static void Main(string[] args)
        {
            int key,sum=0;

            Console.WriteLine("Enter the numbers.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("(The number 0 terminates the program)");
            Console.ResetColor();
            key = int.Parse(Console.ReadLine());

            while (key != 0)
            {
                if (key % 2 != 0 & key > 0) sum+= key;
                key = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("The sum of all odd positive numbers: {0}", sum);
            Pause();
        }

    }

}
