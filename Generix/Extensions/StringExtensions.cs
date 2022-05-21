using System;
using System.Collections.Generic;
using System.Text;

namespace Generix.Extensions
{
    public static class StringExtensions
    {
        public static string PrefixAdrian(this string source, int times)
        {
            string retval = source;

            string prefix = "";
            for (int i = 0; i < times; i++)
            {
                prefix += "ADRIAN - ";
            }
            retval = prefix + retval;

            return retval;
        }
    }
}
