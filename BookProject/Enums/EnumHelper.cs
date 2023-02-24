using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Enums
{
    public static class EnumHelpers
    {
        public static T ReadMenuT<T>(string caption)
        {
            var menus = Enum.GetValues(typeof(T));
            foreach (var item in menus)
            {
                
                Type utype = Enum.GetUnderlyingType(typeof(T));
                var id = Convert.ChangeType(item, utype);
                Console.WriteLine($"{id}.{item}");
            }
            string income;
        label1:
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(caption);
            Console.ForegroundColor = oldcolor;
            income = Console.ReadLine();
            if (!Enum.TryParse(typeof(T), income, out object value) || !Enum.IsDefined(typeof(T), value))
            {
                goto label1;
            }
            return (T)value;

        }
    }
    }




