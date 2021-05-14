using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    static class Utility
    {
        public static void Shuffle<T>(this IList<T> list, Random random)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static string ordinal_suffix_of(int i)
        {
            int j = i % 10;
            int k = i % 100;
            if (j == 1 && k != 11)
            {
                return i + "st";
            }
            if (j == 2 && k != 12)
            {
                return i + "nd";
            }
            if (j == 3 && k != 13)
            {
                return i + "rd";
            }
            return i + "th";
        }
    }
}
