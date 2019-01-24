using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task4
{
    class Task4
    {
        //метод опрделяющий паузу по окончанию программы
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
        private static bool AuthCheck(string Login, string Pass)
        {
            if (Login.Equals("root") & Pass.Equals("GeekBrains"))
                return true;
            else
                return false;
                               }
        private static void Main(string[] args)
        {
            int Attempts = 3; //число попыток
            string[] Authorization = new string[2]; // Логин[1] и пароль[2]
            while (Attempts != 0)
            {
                Console.WriteLine("You have {0} attempts\nEnter login:", Attempts);
                Authorization[0] = Console.ReadLine();
                Console.WriteLine("Enter password:");
                Authorization[1] = Console.ReadLine();

                if (AuthCheck(Authorization[0], Authorization[1]) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Access is allowed");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Attempts--;
                    if (Attempts == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have no more attempts.");
                        Console.ResetColor();
                    }
                }
            }
            Pause();
        }
    }

}
