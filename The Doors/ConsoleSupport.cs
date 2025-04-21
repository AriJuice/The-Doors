using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Doors
{
    internal static class ConsoleSupport
    {
        public static void SpareLine(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rnd = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
