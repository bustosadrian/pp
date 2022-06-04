using Generix.Extensions;
using System;

namespace Generix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world".PrefixAdrian(3));
            Console.WriteLine(StringHelper.PrefixAdrian("Hello world", 3));
            Console.ReadLine();
        }
    }
}
