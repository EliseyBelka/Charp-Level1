using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task7ab
{
    class Task7ab
    {    
        //метод опрделяющий паузу по окончанию программы
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static int Summ(int a, int b)
        {
            Console.Write("{0} ", a);
            if (b == a) return a;
            return a + Summ(a + 1, b);
        }

        private static void Main(string[] args)
        {
            string[] Border = new string[2];
            Console.WriteLine("Enter the boundaries of the interval [a,b] (a<b) by a space");
            Border = Console.ReadLine().Split();
            Console.WriteLine("\nSum of numbers from [{0},{1}] = {2}", Border[0], Border[1], Summ(int.Parse(Border[0]), int.Parse(Border[1])));
            Pause();
        }
    }
}
