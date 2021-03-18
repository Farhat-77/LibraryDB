using System;
using System.Linq;

namespace LibraryDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowDebtors();
            ShowAuthors();
            ShowAvaliableBooks();
            ShowTakedBooks();
            NoMoreSorrow();
        }
        static void ShowDebtors()
        {
            using (BestLibraryEntities db = new BestLibraryEntities())
            {
                Console.WriteLine("--------------- Debtors ---------------");
                var debtors = db.Customers.Where(c => c.IsDebtor == true);
                foreach (var item in debtors)
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
        static void ShowAuthors()
        {
            using (BestLibraryEntities db = new BestLibraryEntities())
            {
                Console.WriteLine("--------------- Authors ---------------");
                var authors = from a in db.BooksInLibrary
                              join b in db.Authors on
                              a.Id_author equals b.Id
                              where a.Id_book == 3
                              select new { FN = b.FirstName, LN = b.LastName };
                foreach (var item in authors)
                {
                    Console.WriteLine($"{item.FN} {item.LN}");
                }
            }
        }
        static void ShowAvaliableBooks()
        {
            using (BestLibraryEntities db = new BestLibraryEntities())
            {
                Console.WriteLine("--------------- Avaliable Books ---------------");
                var a_books = db.BooksInLibrary
                    .Join(db.Books, b => b.Id_book, e => e.Id, (b, e) => new { Title = e.Title, idc = b.Id_customer })
                    .Where(a => a.idc == null);
                foreach (var item in a_books)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }
        static void ShowTakedBooks()
        {
            using (BestLibraryEntities db = new BestLibraryEntities())
            {
                Console.WriteLine("--------------- Taked Books ---------------");
                var book = db.BooksInLibrary
                    .Join(db.Books, b => b.Id_book, e => e.Id, (b, e) => new { Title = e.Title, idc = b.Id_customer })
                    .Join(db.Customers, x => x.idc, y => y.Id, (b, x) => new { idc = x.Id, Title = b.Title })
                    .Where(p => p.idc == 2);

                foreach (var item in book)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }
        static void NoMoreSorrow()
        {
            using (BestLibraryEntities db = new BestLibraryEntities())
            {
                foreach (var item in db.Customers)
                    item.IsDebtor = false;
                db.SaveChanges();
            }
        }
    }
}
