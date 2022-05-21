using System;
using System.Collections.Generic;

namespace GradingStudents
{
    class Result
    {
        private const int FAILING_GRADE = 40;
        private const int GRADE_INTERVAL = 5;
        private const int GRADE_INTERVAL_BREAK = 3;


        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> retval = null;

            retval = new List<int>();
            for (int i = 0; i < grades.Count; i++)
            {
                retval.Add(GradeStudent(grades[i]));
            }

            return retval;
        }

        private static int GradeStudent(int grade)
        {
            int roundedGrade = grade;

            int interval_diff = GRADE_INTERVAL - grade % GRADE_INTERVAL;

            if (interval_diff < GRADE_INTERVAL_BREAK)
            {
                roundedGrade = roundedGrade + interval_diff;
            }

            return roundedGrade < FAILING_GRADE ? grade : roundedGrade;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> grades = new List<int> { 4, 73, 67, 38, 33 };

            var result = Result.gradingStudents(grades);

            Console.WriteLine("Grades");
            Console.WriteLine("**************************");
            foreach (int o in grades)
            {
                Console.WriteLine($"{o}");
            }

            Console.WriteLine();
            Console.WriteLine("Result");
            Console.WriteLine("**************************");
            foreach (int o in result)
            {
                Console.WriteLine($"{o}");
            }

            Console.ReadLine();
        }
    }
}
