using BookProject.DataAuthors;
using BookProject.Infrostructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Managers
{
    public class BookManager : IManager<Book>, IEnumerable<Book>
    {
        Book[] data = new Book[0];
        public void add(Book item)
        {
            int lenght = data.Length;
            Array.Resize(ref data, lenght + 1);
            data[lenght] = item;
        }
        public Book this[int index]
        {
            get
            {
                return data[index];
            }
        }

        public void edit(Book item)
        {
            var index = Array.IndexOf(data, item);
            if (index == -1)
                return;
            var found = data[index];
            found.name = item.name;
            found.AuthorId = item.AuthorId;
            found.page = item.page;
            found.Price = item.Price;
        }
        public void remove(Book item)
        {
            int index = Array.IndexOf(data, item);
            if (index == -1)
                return;
            int lenght = data.Length;
            for (int i = index; i < lenght - 1; i++)
            {
                data[i] = data[i + 1];
                Array.Resize(ref data, lenght - 1);
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Book GetById(int id)
        {
            return Array.Find(data, item => item.id == id);
        }

        public Book[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.name.ToLower().StartsWith(name.ToLower()));
        }

    }
}
