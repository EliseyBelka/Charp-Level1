//Создать программу, которая будет проверять корректность ввода логина.
//Корректным логином будет строка от 2 до 10 символов, содержащая только
//буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//б) ** с использованием регулярных выражений.
//АВТОР исполнения Белканов Алексей
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lesons5
{
    class Task1b
    {
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static void Main(string[] args)      
        {
            
            var pat = @"[a-z,A-Z]{1}[0-9,a-z,A-Z]{1,19}$";
            Regex reg = new Regex(pat);
            Console.WriteLine("Enter a valid login\n(2-20 characters, first not number, [aA-zZ, 0-9])");
            string login = (Console.ReadLine());
            if (reg.IsMatch(login))
                Console.WriteLine("Login accepted");
            else
                Console.WriteLine("Login not accepted");
            Pause();
        }
    }
}
