using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRunTests.PoisonousPlants
{
    internal class Result
    {
        public static int poisonousPlantsV1(List<int> p)
        {
            int days = 0;

            List<int> strongest = p;
            while (true)
            {
                var ar = strongest.ToArray();
                strongest = new List<int>();
                for (int i = ar.Length - 1; i >= 0; i--)
                {
                    var o = ar[i];
                    if (i == 0)
                    {
                        strongest.Insert(0, o);
                    }
                    else
                    {
                        var left = ar[i - 1];

                        if (o <= left)
                        {
                            strongest.Insert(0, o);
                        }
                    }
                }

                if (strongest.Count != ar.Length)
                {
                    days++;
                }
                else
                {
                    break;
                }
            }

            return days;
        }

        public static int poisonousPlantsV2(List<int> p)
        {
            int days = 0;
            int deathPerDays = 0;
            int maxDeathsPerDay = 0;
            var ar = p.ToArray();
            int i = 0;
            while (i < ar.Length)
            {
                var o = ar[i];
                int j;
                deathPerDays = 0;
                for (j = i + 1; j < ar.Length; j++)
                {
                    var k = ar[j];
                    if (o < k)
                    {
                        deathPerDays++;
                        if (deathPerDays > maxDeathsPerDay)
                        {
                            days++;
                            maxDeathsPerDay = deathPerDays;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                i = j;
            }

            return days;
        }


        public static int poisonousPlantsV4(List<int> p)
        {
            int days = 0;
            int lastD = 0;

            var ar = p.ToArray();
            int lastS = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                var o = ar[i];

                if (o > lastS)
                {
                    if (lastD > 0 && o < lastD)
                    {
                        days++;
                    }
                    lastD = o;
                }
                else
                {
                    if(lastD > 0)
                    {
                        //days++;
                    }
                    lastD = 0;
                    lastS = o;
                }
            }

            return days;
        }
    }
}
