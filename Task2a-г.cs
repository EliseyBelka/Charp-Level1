//Разработать класс Message, содержащий следующие статические методы для обработки
//текста:
//а) Вывести только те слова сообщения, которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//Продемонстрируйте работу программы на текстовом файле с вашей программой.
//АВТОР исполнения Белканов Алексей
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesons5
{
    class Task2
    {
        static void Pause()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static void Main(string[] args)
        {
            //Task-a
            Console.WriteLine("Enter a test string");
            string testa = (Console.ReadLine());
            Console.WriteLine("What is the maximum length of words to output?");
            int leng = int.Parse(Console.ReadLine());
            //Вызов метода 
            string[] resulta = (Message.SieveWords(testa, leng));
            //Вывод массива строк переданных из метода
            for (int i = 0; i < resulta.Length; i++)
                Console.Write(resulta[i] + " ");

            //Task-b
            Console.WriteLine("Enter a test string");
            string testb = (Console.ReadLine());
            Console.WriteLine("Which last character in the word should I delete?");
            char charb = Convert.ToChar(Console.ReadLine());
            //Вызов метода 
            string[] resultb = (Message.DeleteWordEndChar(testb, charb));
            //Вывод массива строк переданных из метода
            for (int i = 0; i < resultb.Length; i++)
                Console.Write(resultb[i] + " ");

            //Task-с
            Console.WriteLine("Enter a test string");
            string testс = (Console.ReadLine());
            //Вызов метода 
            Console.WriteLine(Message.LongestWord(testс));

            //Task-d
            Console.WriteLine("Enter a test string");
            string testd = (Console.ReadLine());
            Console.WriteLine("What is the size of the string is considered large?");
            int lengd = int.Parse(Console.ReadLine());
            //Вызов метода 
            Console.WriteLine(Message.SBString(testd,lengd));
            Pause();
        }
    }
}
