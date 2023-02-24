using BookProject.DataAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Infrostructure
{
    public interface IManager<T>
    {
        void add(T item);
        void edit(T item);
        void remove(T item);
        T GetById(int id);
        T[] FindByName(string name);

    }
}
