using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Doors
{
    internal class ConsoleSupport
    {
        public static void SpareLine(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
