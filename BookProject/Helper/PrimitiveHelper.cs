using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Helper
{
    public static class PrimitiveHelper
    {
        public static string ReadString(string caption, bool IsNullOrEmpty = false)
        {
            string income;
        label1:
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(caption);
            Console.ForegroundColor = oldcolor;
            income = Console.ReadLine();
            if (IsNullOrEmpty == false && string.IsNullOrWhiteSpace(income))
            {
                goto label1;
            }
            return income;
        }
        public static int Readint(string caption, int min = 0, int max = 0)
        {
            string income;
        label1:
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            if (min == max && max == 0)
            {
                Console.WriteLine($"{caption} :");
            }
            else
            {
                Console.WriteLine($"{caption} [{min},{max}] :");
            }
            Console.ForegroundColor = oldcolor;
            income = Console.ReadLine();
            if (!int.TryParse(income, out int value) || (min != 0 && max != 0 && (value < min || value > max)))
            {
                goto label1;
            }
            return value;
        }
    }
}
