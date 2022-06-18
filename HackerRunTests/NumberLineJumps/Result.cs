using System;

namespace HackerRunTests.NumberLineJumps
{
    public class Result
    {
        /*
     * Complete the 'kangaroo' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER x1
     *  2. INTEGER v1
     *  3. INTEGER x2
     *  4. INTEGER v2
     */

        public static string kangaroo(int x1, int v1, int x2, int v2)
        {

            bool doTheyMeet;
            try
            {
                var t = WhenDoTheyMeet(x1, v1, x2, v2);
                doTheyMeet = t > 0 && t % 1 == 0;
            }
            catch (DivideByZeroException)
            {
                doTheyMeet = x1 == x2;
            }

            return doTheyMeet ? "YES" : "NO";
        }

        private static double WhenDoTheyMeet(int x1, int v1, int x2, int v2)
        {
            var a = (double)x2 - (double)x1;

            var b = (double)v1 - (double)v2;

            try
            {
                return a / b;
            }
            catch (DivideByZeroException)
            {
                throw;
            }
        }
    }
}
