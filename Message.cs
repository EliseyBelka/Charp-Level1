using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesons5
{
    class Message
    {
        /// <summary>
        /// Поиск "больших" слов
        /// </summary>
        /// <param name="test"></param>
        /// <param name="leng"></param>
        /// <returns></returns>
        public static string[] SieveWordsUp(string test, int up)
        {
            string[] send = { };
            int counter = 0;
            string[] ListOfStrings = test.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in ListOfStrings)
            {
                if (s.Length >= up)
                {
                    Array.Resize(ref send, counter + 1);
                    send[counter] = s;
                    counter++;
                }
            }
            return send;
        }
        /// <summary>
        /// Выделяет слова из строки до указанной длины
        /// </summary>
        /// <param name="test"></param>
        /// <param name="leng"></param>
        /// <returns></returns>
        public static string[] SieveWords (string test, int leng)
        {
            string[] send= { };
            int counter = 0;
            string[] ListOfStrings = test.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in ListOfStrings)
            {
                if (s.Length <= leng)
                {
                    Array.Resize(ref send, counter+1);
                    send[counter] = s;
                    counter++;
                }
            }
            return send;
        }
        /// <summary>
        /// Удаляет слова из строки по последнему, не угодному символу.
        /// </summary>
        /// <param name="test"></param>
        /// <param name="EndChar"></param>
        /// <returns></returns>
        public static string[] DeleteWordEndChar(string test, char EndChar)
        {
            string[] send = { };
            int counter = 0;
            string[] ListOfStrings = test.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in ListOfStrings)
            {
                if (s[s.Length-1] != EndChar)
                {
                    Array.Resize(ref send, counter + 1);
                    send[counter] = s;
                    counter++;
                }
            }
            return send;
        }
        /// <summary>
        /// Определяет самое длинное слово
        /// </summary>
        /// <param name="test"></param>
        /// <param name="EndChar"></param>
        /// <returns></returns>
        public static string LongestWord(string test)
        {
            string send = "";
            int max=-1;
            string[] ListOfStrings = test.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in ListOfStrings)
            {
                if (s.Length>max)
                {
                    send = s;
                    max = s.Length;
                }
            }
            return send;
        }
        /// <summary>
        /// Формирует строку из самых длинных слов
        /// </summary>
        /// <param name="test"></param>
        /// <param name="EndChar"></param>
        /// <returns></returns>
        public static string SBString(string test, int leng)
        {
            string[] work = SieveWordsUp(test, leng);
            StringBuilder SBSting = new StringBuilder();
            string temp= "";
            for (int i = 0; i < work.Length-1; i++)
            {
                for (int j = i + 1; j < work.Length; j++)
                {
                    if (work[i].Length > work[j].Length)
                    {
                        temp = work[i];
                        work[i] = work[j];
                        work[j] = temp;
                    }
                }
            }
            for (int i = 0; i < work.Length; i++)
                SBSting.Append(work[i]+" ");
                return SBSting.ToString();
        }
    }
}
