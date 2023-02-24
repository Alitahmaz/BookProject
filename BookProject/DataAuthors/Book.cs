using BookProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookProject.DataAuthors
{
    public class Book : IEquatable<Book>
    {
        static int counter = 0;
        public Book()
        {
            counter++;
            this.id = counter;
        }
        public string name { get; set; }
        public int id { get; private set; }
        public int AuthorId { get; set; }

        public decimal Price { get; set; }
        public Genre Genre { get; set; }
        public double price;
        public int page;

        public bool Equals(Book? other)
        {
            if (other == null) return false;
            return other?.id == this.id;
        }
        public override string ToString()
        {
            return $" Book Id :{id} || Book Name :{name} || Book PageCount :{page} || Book Price :{price} || Book Genre :{Genre} ||  Book AuthorId :{AuthorId}";
        }
    }
}
