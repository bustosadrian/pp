using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRunTests.AppleAndOrange
{
    public class Result
    {
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
                if (IsIn(sourceLocation, targetLocationWest, targetLocationEast, o))
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
}
