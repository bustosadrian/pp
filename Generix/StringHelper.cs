using System;
using System.Collections.Generic;
using System.Text;

namespace Generix
{
    public static class StringHelper
    {
        public static string PrefixAdrian(string source, int times)
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
