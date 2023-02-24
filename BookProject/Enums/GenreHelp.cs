using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Enums
{
    public static class GenreHelpers
    {
        public static T ReadGenreT<T>(string caption)
        {
            var genres = Enum.GetValues(typeof(T));
            foreach (var item in genres)
            {
                //int id = Convert.ToByte(item);
                Type utype = Enum.GetUnderlyingType(typeof(T));
                var id = Convert.ChangeType(item, utype);
                Console.WriteLine($"{id}.{item}");
            }
            string income;
        label1:
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
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

