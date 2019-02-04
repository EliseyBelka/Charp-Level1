//Создать программу, которая будет проверять корректность ввода логина.
//Корректным логином будет строка от 2 до 10 символов, содержащая только 
//буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;
//АВТОР исполнения Белканов Алексей 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesons5
{
    class Task1
    {
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static void Main(string[] args)
        {
            string login;
            int checksum=0;
            Console.WriteLine("Enter a username between 2 to 20 characters");
            login=Console.ReadLine();
           //Console.WriteLine((int)login[0]);
            if (login.Length <= 1 | login.Length >= 21)
            {
                Console.WriteLine("Error. Length of the login does not meet the conditions");
            } else
                    if ((int)login[0] >= 48 & (int)login[0] <= 57)
                    Console.WriteLine("Error. Login should not start with a number.");
                      else
                    foreach (char ch in login)
                    {
                       // Console.WriteLine((int)ch);
                        if ((int)ch >= 48 && (int)ch <= 57 | (int)ch >= 65 && (int)ch <= 90 | (int)ch >= 97 && (int)ch <= 122)
                        {
                        checksum++;
                        } else
                        {
                        checksum--;
                        }
                    }
            if (checksum == login.Length)
                Console.WriteLine("Login is correct");
            else
                Console.WriteLine("Login is not correct");
            Pause();
        }
        
    }
}
