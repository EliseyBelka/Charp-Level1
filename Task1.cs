//Изменить программу вывода функции так, чтобы можно было передавать функции типа 
//double (double, double). Продемонстрировать работу на функции с функцией a* x^2
//и функцией a* sin(x).
//Автор исполнения Белканов Алексей
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    /// <summary>
    /// Делегат со ссылкой на метод возвращающий значения типа double
    /// </summary>
    /// <param name="x">  параметр double </param>
    /// <param name="y">  параметр double</param>
    /// <returns></returns>
    delegate double Function(double x, double y);

    class Task1
    {
        /// <summary>
        /// Вычисляет a*x^2
        /// </summary>
        /// <param name="a">a*x^2</param>
        /// <param name="x">a*x^2</param>
        /// <returns></returns>
        static double FunctionAX2  (double a, double x)
        {
            return a * x * x;
        }
        /// <summary>
        /// Вычисляет a*Sin(x)
        /// </summary>
        /// <param name="a">a*Sin(x)</param>
        /// <param name="x">a*Sin(x)</param>
        /// <returns></returns>
        static double FunctionASINX(double a, double x)
        {
            return a * Math.Sin(x);
        }
        /// <summary>
        /// Ожидание при завершение работы консоли
        /// </summary>
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static void Main(string[] args)
        {
            Function first = new Function(FunctionAX2);
            Function second = new Function(FunctionASINX);

            double x1 = 0, x2 = 0;
            double a1,a2;
            #region Ввод параметров функции
            Console.WriteLine("Specify the range of X1 values [x1..x2]");
            x1 = double.Parse(Console.ReadLine().Replace(",", "."));
            Console.WriteLine("Specify the range of X2 values [x1..x2]");
            x2 = double.Parse(Console.ReadLine().Replace(",", "."));
            Console.WriteLine("Specify the a for function a*x^2");
            a1 = double.Parse(Console.ReadLine().Replace(",", "."));
            Console.WriteLine("Specify the a for function a*Sin(x)");
            a2 = double.Parse(Console.ReadLine().Replace(",", "."));
            #endregion

            Console.WriteLine("----------x- ------a*x^2- -----asinx-");
            while (x1 != x2)
            {
                Console.WriteLine("| {0,9:0.000} | {1,9:0.000} | {2,9:0.000} |", x1, first(a1,x1), second(a2, x1));
                x1+=0.5;
            }
            Console.WriteLine("--------------------------------------");

            Pause();
        }
    }
}
