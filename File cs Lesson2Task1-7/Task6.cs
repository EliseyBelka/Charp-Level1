using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task6
{
    class Task6
    {        //метод опрделяющий паузу по окончанию программы
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
        static int SumNum(int number)
        {
            int Sum = 0;
            while (number > 0)
            {
                Sum = Sum + number % 10;      //рекурсивный метод (работает быстро но ->
                number = SumNum(number / 10); //недостаточно что бы дождаться окончания) p.s. должно быть формула в алгебре
            }
            return Sum;
        }
        private static void Main(string[] args)
        {
            uint Counter = 0;
            DateTime Start = DateTime.Now;
            for (int i = 1; i <= 1000000000; i++)
            {
                Console.WriteLine("{0}", i);
                if (i % SumNum(i) == 0) Counter++;
            }
            Console.WriteLine("Good numbers: {0}. Lead time: {1}", Counter, DateTime.Now - Start);
            Pause();
        }
    }
}
