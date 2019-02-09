//Переделать программу Пример использования коллекций для решения следующих задач:
//а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
//б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе 
//учатся(*частотный массив);
//в) отсортировать список по возрасту студента;
//г) * отсортировать список по курсу и возрасту студента;?
//Автор исполнения Белканов Алексей
using System;
using System.Collections.Generic;
using System.IO;


namespace Lesson6
{
    /// <summary>
    /// Класс студент содержит информацию: Фамилию, Имя, университет, факультет, курс, кафедра, группа, город,возраст
    /// </summary>
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public string department;
        public int age;
        public int course;
        public int group;
        public string city;
       
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age,  int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }

    class Task3
    {   /// <summary>
        /// Сравнение двух объектов класса Студент
        /// </summary>
        /// <param name="st1">Параметры 1 студента</param>
        /// <param name="st2">Параметры 2 студента</param>
        /// <returns></returns>
        static int Сomparison(Student st1, Student st2)
        {
            return String.Compare(st1.firstName, st2.firstName);          
        }

        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            int Сourse56 = 0;
            int[] Frequency = new int[3];
            List<Student> list = new List<Student>();                             
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_6.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[5]) < 5) bakalavr++; else magistr++;
                    //taskA
                    if (int.Parse(s[5]) == 5 | int.Parse(s[5]) == 6) Сourse56++;
                    //taskB
                    if (int.Parse(s[6]) == 18) Frequency[0]++;
                    if (int.Parse(s[6]) == 19) Frequency[1]++;
                    if (int.Parse(s[6]) == 20) Frequency[2]++;
                    //taskC
                    list.Sort(delegate (Student list1, Student list2)
                    { return list1.age.CompareTo(list2.age); });
                    list.Sort(delegate (Student list1, Student list2)
                    { return list1.course.CompareTo(list2.course); });


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
           // list.Sort(new Comparison<Student>(Сomparison));
            Console.WriteLine("Всего студентов: " + list.Count);
            Console.WriteLine("Магистров: {0}", magistr);
            Console.WriteLine("Бакалавров: {0}", bakalavr);
            Console.WriteLine("Студенто на 5 и 6 курсе: {0}", Сourse56);
            Console.WriteLine("Студенты 18лет-{0} 19лет-{1} 20лет-{2}", Frequency[0],Frequency[1],Frequency[2]);


            Console.WriteLine("Фамилии студентов:");
            foreach (var v in list)
                Console.WriteLine("{0,9} | {1,1} | {2,2} | ", v.firstName, v.course, v.age);
            Console.WriteLine("Время выполнения программы:");
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}
