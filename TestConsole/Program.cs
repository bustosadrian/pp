//using SuperReducedString;

using QueensAttack;
using SuperReducedString;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestSuperReducedString();
            TestQueensAtack();
        }

        private static void TestSuperReducedString()
        {
            SuperReducedStringResultTest.Test1();
            SuperReducedStringResultTest.Test2();
            SuperReducedStringResultTest.Test3();   
            SuperReducedStringResultTest.Test4();
        }

        private static void TestQueensAtack()
        {
            QueensAttackResultTest.Test1();
            QueensAttackResultTest.Test2();
            QueensAttackResultTest.Test20();


            //QueensAttackResultTest.Test3();
        }
    }
}
