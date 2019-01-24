using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task5a
{
    class Task5a
    {//метод опрделяющий паузу по окончанию программы
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
        static string question(string quest) // метод задающий вопрос и принимающий ответ
        {
            Console.Write(quest);
            return Console.ReadLine();
        }
        static double InputDouble(string quest) // метод спрашивает данные на ввод+преобразование в число+учет ввода . а не , в плавающем
        {
            return double.Parse(question(quest).Replace(".", ","));
        }

        private static void Main(string[] args)
        {
            double Weight = InputDouble("Enter weight in Kilograms(kg): ");
            double Growth = InputDouble("Enter height in Meters(m): ");
            double BMI = Weight / Math.Pow(Growth, 2);
            // Console.WriteLine("With weight {0} m and growth {1} kg.\nBMI={2:F2}", Weight, Growth, BMI);
            Console.WriteLine("BMI={0:F2}", BMI);
            if (BMI > 18.5 & BMI < 24.99)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Weight OK");
                Console.ResetColor();
            }
            else if (BMI < 18.5)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Lack of weight");
                Console.WriteLine("You must dial: from {0:F2} to {1:F2} kg",
                    (18.5 - BMI) * Math.Pow(Growth, 2), (24.99 - BMI) * Math.Pow(Growth, 2));
                Console.ResetColor();
            }
            else if (BMI > 24.99)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Excess weight");
                Console.WriteLine("Need to reset: from {0:F2} to {1:F2} kg",
                (BMI - 24.99) * Math.Pow(Growth, 2), (BMI - 18.5) * Math.Pow(Growth, 2));
                Console.ResetColor();
            }
            Pause();
        }
    }
} 

