using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task2
{
    class Task2
    { //метод опрделяющий паузу по окончанию программы
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static int account()
        {
            Console.Write("Enter \"int\" or \"double\" number : ");
            int counter = 0;     //счетчик количества
            int IntPart;         //целая часть введенного числа
            double FractPart;    //дробная часть введенного числа
            int temp;           //временная переменная для работы с дробью
            string answer;      //ответ пользователя

            //Блок исключения 0 (для таких случаев 0.000 , 000.0000, 010101.01010)
            answer = Console.ReadLine().Replace(".", ",");
            for (int i = answer.Length - 1; i >= 0; i--)
                if (answer[i] == '0')
                {
                    answer = answer.Remove(i, 1);
                    counter++;
                }

            //Блок основного метода
            if (answer != "" & answer != ",")
            {
                double number = Convert.ToDouble(answer);
                IntPart = (int)number;
                FractPart = Math.Round(number - IntPart, 14); //округление обязательно из-за особенностей 2й СС с 15 знака накопление ошибки.

                //Блок проверки числа цифр в целой части
                while (IntPart != 0)
                {
                    IntPart /= 10;
                    counter++;
                }

                //Блок проверки числа цифр в дробной части
                while (FractPart != 0)
                {
                    temp = (int)(FractPart * 10);
                    FractPart = Math.Round(FractPart * 10 - temp, 14);
                    counter++;
                }
            }
            return counter;

        }

        private static void Main(string[] args)
        {
            Console.Write("Of digits in a number {0}", account());
            Pause();
        }
    }

}
