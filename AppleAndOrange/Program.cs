using System;
using System.Collections.Generic;

namespace AppleAndOrange
{
    class Result
    {

        /*
         * Complete the 'countApplesAndOranges' function below.
         *
         * The function accepts following parameters:
         *  1. INTEGER s
         *  2. INTEGER t
         *  3. INTEGER a
         *  4. INTEGER b
         *  5. INTEGER_ARRAY apples
         *  6. INTEGER_ARRAY oranges
         */

        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            Console.WriteLine(Count(a, s, t, apples));
            Console.WriteLine(Count(b, s, t, oranges));
        }

        private static int Count(int sourceLocation, int targetLocationWest, int targetLocationEast, List<int> items)
        {
            int retval = 0;
            foreach (var o in items)
            {
                if(IsIn(sourceLocation, targetLocationWest, targetLocationEast, o))
                {
                    retval++;
                }
            }

            return retval;
        }

        private static bool IsIn(int sourceLocation, int targetLocationWest, int targetLocationEast, int item)
        {
            int itemLocation = sourceLocation + item;
            return itemLocation >= targetLocationWest && itemLocation <= targetLocationEast;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test1");
            Test1();
            Console.WriteLine("");

            Console.WriteLine("Test2");
            Test2();
            Console.WriteLine("");

            Console.ReadLine();
        }

        static void Test1()
        {
            int s = 7;
            int t = 11;
            int a = 5;
            int b = 15;

            List<int> apples = new List<int> { -2, 2, 1 };
            List<int> oranges = new List<int> { 5, -6 };

            Result.countApplesAndOranges(s, t, a, b, apples, oranges);
        }

        static void Test2()
        {
            int s = 2;
            int t = 3;
            int a = 1;
            int b = 5;

            List<int> apples = new List<int> { 2 };
            List<int> oranges = new List<int> { -2 };

            Result.countApplesAndOranges(s, t, a, b, apples, oranges);
        }
    }
}
