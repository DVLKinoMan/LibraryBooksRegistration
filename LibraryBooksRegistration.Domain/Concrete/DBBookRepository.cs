using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryBooksRegistration.Domain.Abstract;
using LibraryBooksRegistration.Domain.Entities;
using System.Data.SqlClient;

namespace LibraryBooksRegistration.Domain.Concrete
{
    public class DBBookRepository : IBookRepository
    {
        private LibraryBooksRegistrationDatabaseModel context = new LibraryBooksRegistrationDatabaseModel();

        public IEnumerable<Book> Books { get { return context.Books; } }

        public Book GetBookByID(int bookid)
        {
            return context.Books.Where(b => b.ID == bookid).FirstOrDefault();
        }
        public int AddBook(Book book)
        {
            context.Database.ExecuteSqlCommand(
                       "exec AddBook @Name, @CategoryID, @PublishingHouse, @PublishingDate",
                       new SqlParameter("Name", book.Name),
                       new SqlParameter("CategoryID", book.CategoryID),
                       new SqlParameter("PublishingHouse", book.PublishingHouse),
                       new SqlParameter("PublishingDate", book.PublishingDate)
                   );
            return context.Books.ToList().Last().ID;
        }

        public void EditBook(Book book)
        {
            context.Database.ExecuteSqlCommand(
                       "exec EditBook @ID, @Name, @CategoryID, @PublishingHouse, @PublishingDate",
                       new SqlParameter("ID",book.ID),
                       new SqlParameter("Name", book.Name),
                       new SqlParameter("CategoryID", book.CategoryID),
                       new SqlParameter("PublishingHouse", book.PublishingHouse),
                       new SqlParameter("PublishingDate", book.PublishingDate)
                   );
        }

        public void DeleteBook(Book book)
        {
            context.Database.ExecuteSqlCommand(
                       "exec DeleteBook @ID",
                       new SqlParameter("ID", book.ID)
                   );
        }
    }
}
