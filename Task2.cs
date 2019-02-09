//Модифицировать программу нахождения минимума функции так, чтобы можно было передавать 
//    функцию в виде делегата.
//а) Сделать меню с различными функциями и представить пользователю выбор, для какой 
//    функции и на каком отрезке находить минимум.Использовать массив(или список) делегатов,
//    в котором хранятся различные функции.
//б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она 
//    возвращает минимум через параметр(с использованием модификатора out). 
//Автор исполнения Белканов Алексей
using System;
using System.IO;
using System.Collections.Generic;

namespace DoubleBinary
{
    /// <summary>
    /// Делегат позволяющий вфбрать функцию F(x)
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    delegate double FunC(double x);


    class Program
    {   /// <summary>
        /// расчет функции x * x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Fxx(double x)
        {
            return x * x;
        }
        /// <summary>
        /// расчет функции 50*x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double F50x(double x)
        {
            return 50*x;
        }
        /// <summary>
        /// расчет функции x * x-50*x+10
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Fstandart(double x)
        {
            return x * x - 50 * x + 10;
        }
        /// <summary>
        /// Сохранение результатов вычисления функции в файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="h"></param>
        public static void SaveFunc(string fileName, double a, double b, double h, FunC FS)
        {
            
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(FS(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        /// <summary>
        /// Загрузка значений из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static double[] Load(string fileName, out double min)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                min = double.MaxValue;
                double d;
                double[] sendar= { };
                for (int i = 0; i < fs.Length / sizeof(double); i++)
                {
                    // Считываем значение и переходим к следующему
                    d = bw.ReadDouble();
                    Array.Resize(ref sendar, i+1);
                    sendar[i] = d;
                   // Console.Write(d+" ");
                    if (d < min) min = d;
                }
                bw.Close();
                fs.Close();
                return sendar;
            }

        static void Main(string[] args)
        {
            double min;
            int i = 0, x1, x2;
            double[] mass = { };
            FunC FunSelect=null;

            #region Б. Вывод списка функций через делигат use List и вопрос о выборе функции
            List<FunC> ListFunc = new List<FunC>() { Fxx, F50x, Fstandart };
            Console.WriteLine("Available function list:");
            foreach (var list in ListFunc)
            {
                Console.WriteLine((i+1)+" "+list.Method);
                i++;
            }
            Console.WriteLine("How to function perform No:");
            i = int.Parse(Console.ReadLine());
            #endregion
          
            #region А. Обработка выбраной функции
            switch (i)
            {
                case 1:
                    FunSelect= Fxx;
                    break;
                case 2:
                    FunSelect = F50x;
                    break;
                case 3:
                    FunSelect = Fstandart;
                    break;
                default:
                    Console.WriteLine("Function does not exist");
                    break;
            }
            #endregion

            #region А. Выбор интервала значений [x1..x2]
            Console.WriteLine("At what interval [x1..x2] will the function be executed X1:");
            x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("At what interval [x1..x2] will the function be executed X2:");
            x2 = int.Parse(Console.ReadLine());
            #endregion

            SaveFunc("data.bin", x1, x2, 0.5, FunSelect);
            mass =  (Load("data.bin", out min));

            #region В* Вывод элементов массива функции Load и вывод минимальное значения как параметр
            Console.WriteLine("\nElements passed as an array from the LOAD function: ");
            for (int j = 0; j < mass.Length; j++)
            Console.Write(mass[j]+" ");
            Console.WriteLine("\nThe minimum value passed as a parameter: " + min);
            #endregion
            Console.ReadKey();
        }
    }
}


