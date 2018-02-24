using System;

namespace Hello_World
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*int[] gradesasc = { 1, 2, 3, 6, 9 };
            int[] gradesdesc = { 11, 8, 5, 3, 1 };
            Console.WriteLine(IsSorted(gradesasc, false));
            Console.WriteLine(IsSorted(gradesdesc, false));*/
        }
        public static bool IsSorted(int[] grades, bool asc)
        {
            int LastGrade = grades[0];
            foreach (int grade in grades)
            {
                if (asc)
                {
                    if (grade > LastGrade)
                    {
                        return false;
                    }
                    else
                    {
                        LastGrade = grade;
                    }
                }

                else
                {
                    if (grade < LastGrade)
                    {
                        return false;
                    }
                    else
                    {
                        LastGrade = grade;
                     }
                }
            }
            return true;

        }

    }
}