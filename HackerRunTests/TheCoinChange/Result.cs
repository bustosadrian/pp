using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRunTests.TheCoinChange
{
    public class Result
    {
        public static long getWays(int n, List<long> c)
        {
            long changes = 0;
            var coins = Sort(n, c);

            Dictionary<string, long> cache = new Dictionary<string, long>();

            for(int i = 0; i < coins.Length; i++)
            {
                changes += FindChanges(n, coins, i, cache);
            }

            return changes;
        }

        private static int[] Sort(long amount, List<long> coins)
        {
            return coins.Where(x => x <= amount).OrderByDescending(x => x).Select(x => (int)x).ToArray();
        }

        private static long FindChanges(int n, int[] coins, int index, Dictionary<string, long> cache)
        {
            
            long changes = 0;

            int coin = coins[index];

            var key = $"{n},{coin}";

            if(cache.TryGetValue(key, out long cachedChanges))
            {
                return cachedChanges;
            }

            int quotient = n / coin;
            int rest = n % coin;

            if(quotient == 0)
            {
                return 0;
            }

            if (rest == 0)
            {
                changes++;
                quotient--;
            }

            while (quotient > 0)
            {
                for(int i = index + 1; i < coins.Length; i++)
                {
                    int n2 = n - quotient * coin;
                    changes += FindChanges(n2, coins, i, cache);
                }
                
                quotient--;
            }

            cache.Add(key, changes);

            return changes;
        }
    }
}
