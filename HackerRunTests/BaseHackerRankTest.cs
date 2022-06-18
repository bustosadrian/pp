using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;

namespace HackerRunTests
{
    public abstract class BaseHackerRankTest
    {
        protected T Parse<T>(string text, int index)
        {
            string value = Split(text)[index];

            return ParseValue<T>(value);
        }

        protected IEnumerable<T> ParseAll<T>(string text, params int[] values)
        {
            string[] ar = Split(text);
            T[] retval = (T[])Array.CreateInstance(typeof(T), ar.Length);
            for (int i = 0; i < ar.Length; i++)
            {
                retval[i] = ParseValue<T>(ar[i]);
            }

            return retval;
        }

        private T ParseValue<T>(string value)
        {
            object retval = null;
            if (typeof(T).Equals(typeof(int)))
            {
                retval = int.Parse(value);
            }
            if (typeof(T).Equals(typeof(long)))
            {
                retval = long.Parse(value);
            }

            return (T)retval;
        }

        protected string[] Split(string text)
        {
            return text.Split(' ').Where(x => x.Length > 0).ToArray();
        }
    }
}
