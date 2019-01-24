using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class Task1
    {
        //метод опрделяющий паузу по окончанию программы
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
        //метод определяющий минимальнео из 3 чисел
        private static double mini(double a, double b, double c)
        {
            double min = 0;
            if ((a < b) & (a < c)) min = a;
            else if (b < c) min = b;
            else min = c;
            return min;
        }

        private static void Main(string[] args)
        {
            string[] number = new string[2];

            while (number[0] == "" | number.Length <= 2) //первый символ не пробел | введены все три числа
            {
                if (number[0] == "") Console.WriteLine("Input should start with a number");
                else Console.WriteLine("Enter 3 numbers separated by a space");
                number = Console.ReadLine().Replace('.', ',').Split();
            }
            Console.WriteLine("A minimum of three digits: {0}  {1}  {2} It is {3}",
                                double.Parse(number[0]), double.Parse(number[1]), double.Parse(number[2]),
                                    mini(double.Parse(number[0]), double.Parse(number[1]), double.Parse(number[2])));
            Pause();
        }
    }

}
