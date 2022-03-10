using System;
using System.Collections.Generic;
using System.Linq;
using static PA1LibFramework.Class1;

namespace ConsoleApp1
{
    internal class Program
    {
        public static List<Student> studentsdata = new List<Student>()
        { new Student(new DateTime(2002, 12, 12), 1242, "Ахмед Ахмедо Ахмедович"),
          new Student(new DateTime(2002, 12, 11), 1242, "Ахмед Ахмедо Ахмедович"),
          new Student(new DateTime(2002, 12, 24), 1222, "Ахмед Ахмедо Ахмедович"),
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Тест метода:");
            int variant = Convert.ToInt32(Console.ReadLine());

            switch (variant)
            {
                case 0:
                    Console.WriteLine("Данные: ");
                    string checkData = Console.ReadLine();

                    AvgTest(checkData.Split(' '));
                    break;
                case 1:
                    FirstTest();
                    break;
                case 2:
                    SecondTest();
                    break;
                case 3:
                    ThirdTest();
                    break;
                case 4:
                    FourdTest();
                    break;
            }

            Console.ReadLine();
        }

        public static void AvgTest(string[] checkData)
        {
            Console.WriteLine(MinAVG(checkData));
        }

        public static void FirstTest()
        {
            List<Mark> marks = GetMarks(new DateTime(2020, 12, 10), studentsdata);
            marks.AddRange(GetMarks(new DateTime(2020, 10, 9), studentsdata));
            marks.AddRange(GetMarks(new DateTime(2020, 9, 9), studentsdata));
            marks.AddRange(GetMarks(new DateTime(2020, 8, 9), studentsdata));

            foreach (Mark mark in marks)
            {
                Console.WriteLine($"{mark.Date}:{GetStudNumber(mark.StudentData.AdmissionYear.Year, mark.StudentData.ClassGroup, mark.StudentData.FullName)}:{mark.Estimation}");
            }

            int[] data = GetCountTruancy(marks);

            foreach(int num in data)
            {
                Console.Write($"{num} ");
            }
        }

        public static void SecondTest()
        {
            List<Mark> marks = GetMarks(new DateTime(2020, 12, 10), studentsdata);
            marks.AddRange(GetMarks(new DateTime(2020, 10, 9), studentsdata));
            marks.AddRange(GetMarks(new DateTime(2020, 9, 9), studentsdata));
            marks.AddRange(GetMarks(new DateTime(2020, 8, 9), studentsdata));

            foreach (Mark mark in marks)
            {
                Console.WriteLine($"{mark.Date}:{GetStudNumber(mark.StudentData.AdmissionYear.Year, mark.StudentData.ClassGroup, mark.StudentData.FullName)}:{mark.Estimation}");
            }


            int[] data = GetCountDisease(marks);

            foreach (int num in data)
            {
                Console.Write($"{num} ");
            }
        }

        public static void ThirdTest()
        {
            Console.WriteLine(GetStudNumber(studentsdata[0].AdmissionYear.Year, studentsdata[0].ClassGroup, studentsdata[0].FullName));
        }

        public static void FourdTest()
        {
            List<Mark> marks = GetMarks(new DateTime(2020, 12, 10), studentsdata);
            foreach(Mark mark in marks)
            {
                Console.WriteLine($"{mark.Date}:{GetStudNumber(mark.StudentData.AdmissionYear.Year, mark.StudentData.ClassGroup, mark.StudentData.FullName)}:{mark.Estimation}");
            }
        }
    }

    public class Class1
    {
        
    }
}