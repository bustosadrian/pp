using System;
using System.Collections.Generic;

namespace GradingStudents
{
    class Program
    {
        private const int FAILING_GRADE = 40;

        static void Main(string[] args)
        {
            List<int> grades = new List<int> { 4, 73, 67, 38, 33 };


            var result = GradingStudents(grades);

            for(int i = 0; i < grades.Count; i++)
            {
                Console.WriteLine($"{grades[i]}: {result[i]}");
            }

            Console.ReadLine();
        }

        private static List<int> GradingStudents(List<int> grades)
        {
            List<int> retval = null;

            retval = new List<int>();
            for(int i = 0; i < grades.Count; i++)
            {
                retval.Add(GradeStudent(grades[i]));
            }

            return retval;
        }

        private static int GradeStudent(int grade)
        {
            int roundedGrade = grade;

            int interval = 5 - grade % 5;

            if(interval < 3)
            {
                roundedGrade = roundedGrade + interval;
            }

            if(roundedGrade < FAILING_GRADE)
            {
                roundedGrade = grade;
            }

            return roundedGrade;
        }
    }
}
