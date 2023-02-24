using BookProject.DataAuthors;
using BookProject.Enums;
using BookProject.Helper;
using BookProject.Managers;

namespace BookProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookManager bookmanagers = new BookManager();
            AuthorManager authormanagers = new AuthorManager();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("              BookXana.az");

            Console.WriteLine("Isdifade edeceyiniz menunu secin!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            var selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");

            Author author;
            int id;
        label1: switch (selectedmenu)
            {
                case MenuTypes.AuthorAdd:
                    author = new Author();
                    author.Name = PrimitiveHelper.ReadString("Muellifin adi :");
                    author.Surname = PrimitiveHelper.ReadString("Muellifin Soyadi :");
                    authormanagers.add(author);
                    Console.Clear();
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");

                    goto label1;

                case MenuTypes.AuthorEdit:
                    Console.WriteLine("Redakte etmek isdediyiniz muellifi secin");
                    foreach (var item in authormanagers)
                    {
                        Console.WriteLine(item);
                    }
                    id = PrimitiveHelper.Readint("Muelli id-si :");
                    if (id == 0)
                    {
                        Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                        selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                        goto label1;
                    }
                    author = authormanagers.GetById(id);
                    if (author == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.AuthorEdit;
                    }
                    author.Name = PrimitiveHelper.ReadString("Muellifin adi :");
                    author.Surname = PrimitiveHelper.ReadString("Muellifin soyadi :");
                    Console.Clear();
                    goto case MenuTypes.AuthorGetAll;
                case MenuTypes.AuthorRemove:
                    Console.WriteLine("Silmek  isdediyiniz muellifi secin");
                    foreach (var item in authormanagers)
                    {
                        Console.WriteLine(item);
                    }
                    id = PrimitiveHelper.Readint("Muelli id-si :");
                    author = authormanagers.GetById(id);
                    if (author == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.AuthorRemove;
                    }
                    authormanagers.remove(author);
                    Console.Clear();
                    goto case MenuTypes.AuthorGetAll;
                    foreach (var item in authormanagers)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                    goto label1;
                case MenuTypes.AuthorGetAll:
                    Console.Clear();
                    foreach (var item in authormanagers)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");

                    goto label1;
                case MenuTypes.AuthorFindByName:
                    string name = PrimitiveHelper.ReadString("Axtaris ucun en az 3 herf daxil edin :");
                    var data = authormanagers.FindByName(name);
                    if (data.Length == 0)
                    {
                        Console.WriteLine("Tapilmadi");
                    }
                    foreach (var item in data)
                    {
                        Console.WriteLine(item);

                    }

                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");

                    goto label1;
                case MenuTypes.AuthorGetById:
                    id = PrimitiveHelper.Readint("Muelli id-si :");
                    if (id == 0)
                    {
                        Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                        selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                        goto label1;
                    }
                    author = authormanagers.GetById(id);
                    if (author == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Tapilmadi");
                        goto case MenuTypes.AuthorGetById;
                    }
                    Console.WriteLine(author);
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                    break;

                case MenuTypes.BookAdd:
                    Book book = new Book();
                    book.name = PrimitiveHelper.ReadString("Kitabin adi :");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                l3: Console.WriteLine("Kitabin sehvesini daxil edin");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int pagecount;
                    if (int.TryParse(Console.ReadLine(), out pagecount) == false)
                    {
                        Console.WriteLine("Sehvelerin sayi tam eded olmalidir");
                        goto l3;
                    }
                    if (pagecount < 0)
                    {
                        Console.WriteLine("Kitabin sehvesi menfi eded ola bilmez");
                        goto l3;
                    }
                    book.page = pagecount;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                l4: Console.WriteLine("Kitabin qiymetini daxil edin");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    double bookprice;
                    if (double.TryParse(Console.ReadLine(), out bookprice) == false)
                    {
                        Console.WriteLine("Sehvelerin sayi tam eded olmalidir");
                        goto l4;
                    }
                    if (bookprice < 0)
                    {
                        Console.WriteLine("Qiymet menfi eded ola bilmez");
                        goto l4;
                    }
                    foreach (var item in authormanagers)
                    {
                        Console.WriteLine(item);
                    }
                    book.price = bookprice;
                    id = PrimitiveHelper.Readint("Muelli id-si :");
                    Console.WriteLine("Kitabin janrini secin:");
                    var selectedgenre = GenreHelpers.ReadGenreT<Genre>("kitabin janri  :");
                    book.Genre = selectedgenre;
                    bookmanagers.add(book);
                    Console.Clear();
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");

                    goto label1;

                case MenuTypes.BookEdit:
                    Console.WriteLine("Redakte etmek isdediyiniz kitabi secin");
                    foreach (var item in bookmanagers)
                    {
                        Console.WriteLine(item);
                    }

                    id = PrimitiveHelper.Readint("Kitabin id-si :");
                    if (id == 0)
                    {
                        Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                        selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                        goto label1;
                    }
                    book = bookmanagers.GetById(id);
                    if (book == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.BookEdit;
                    }
                    book.name = PrimitiveHelper.ReadString("kitabin adi :");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Kitabin sehvesi :");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (int.TryParse(Console.ReadLine(), out pagecount) == false)
                    {
                        Console.WriteLine("Sehvelerin sayi tam eded olmalidir");
                        goto l3;
                    }
                    if (pagecount < 0)
                    {
                        Console.WriteLine("Sehve menfi eded ola bilmez");
                        goto l4;
                    }
                    book.AuthorId = PrimitiveHelper.Readint("Muellifin id-si");
                    book.page = pagecount;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Kitabin qiymeti :");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (double.TryParse(Console.ReadLine(), out bookprice) == false)
                    {
                        Console.WriteLine("Duzgun daxil edin");
                        goto l4;
                    }
                    if (bookprice < 0)
                    {
                        Console.WriteLine("Qiymet menfi eded ola bilmez");
                        goto l4;
                    }
                    book.price = bookprice;
                    var selectedgenre2 = GenreHelpers.ReadGenreT<Genre>("kitabin janri  :");
                    book.Genre = selectedgenre2;
                    Console.Clear();
                    goto case MenuTypes.BookGetAll;

                case MenuTypes.BookRemove:
                    Console.WriteLine("Silmek  isdediyiniz kitabi secin");
                    foreach (var item in bookmanagers)
                    {
                        Console.WriteLine(item);
                    }
                    id = PrimitiveHelper.Readint("kitabin id-si :");
                    book = bookmanagers.GetById(id);
                    if (book == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.BookRemove;
                    }
                    bookmanagers.remove(book);
                    Console.Clear();
                    goto case MenuTypes.BookGetAll;
                    foreach (var item in bookmanagers)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                    goto label1;

                case MenuTypes.BookGetAll:
                    Console.Clear();
                    foreach (var item in bookmanagers)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                    goto label1;
                case MenuTypes.BookFindByName:
                    Console.Clear();
                    string name2 = PrimitiveHelper.ReadString("Axtaris ucun en az 3 herf daxil edin :");
                    var dataa = bookmanagers.FindByName(name2);
                    if (dataa.Length == 0)
                    {
                        Console.WriteLine("Tapilmadi");
                    }
                    foreach (var item in dataa)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");

                    goto label1;

                case MenuTypes.BookGetById:
                    id = PrimitiveHelper.Readint("kitabin id-si :");
                    if (id == 0)
                    {
                        Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                        selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                        goto label1;
                    }
                    book = bookmanagers.GetById(id);
                    if (book == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Tapilmadi");
                        goto case MenuTypes.AuthorGetById;
                    }
                    Console.WriteLine(book);
                    Console.WriteLine("Isdifade edeceyiniz menunu secin!");
                    selectedmenu = EnumHelpers.ReadMenuT<MenuTypes>("Menu  :");
                    break;
            }
        }
    }
        }

