using System;
using System.Text;

namespace SuperReducedString
{
    class Result
    {

        /*
         * Complete the 'superReducedString' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string superReducedString(string s)
        {
            char[] ar = s.ToCharArray();

            StringBuilder sb = new StringBuilder();

            char? currentChar = null;
            int currentCharCount = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                char o = ar[i];
                if (currentChar != o)
                {
                    if (currentCharCount % 2 > 0)
                    {
                        sb.Append(currentChar);
                    }
                    currentCharCount = 1;
                    currentChar = o;
                }
                else
                {
                    currentCharCount += 1;
                }
            }
            if (currentCharCount % 2 > 0)
            {
                sb.Append(currentChar);
            }

            if (sb.Length == s.Length)
            {
                return sb.Length == 0 ? "Empty String" : sb.ToString();
            }
            else
            {
                return superReducedString(sb.ToString());
            }
        }
    }

    public class SuperReducedStringResultTest
    {
        private static void Test(string s)
        {
            Console.WriteLine($"{s}: {Result.superReducedString(s)}");
        }


        public static void Test1()
        {
            Test("aab");
        }

        public static void Test2()
        {
            Test("abba");
        }

        public static void Test3()
        {
            Test("aaabccddd");
        }

        public static void Test4()
        {
            Test("abbceaa");
        }
    }
}
