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
    public class DBAuthorBookRepository: IAuthorBookRepository
    {
        private LibraryBooksRegistrationDatabaseModel context = new LibraryBooksRegistrationDatabaseModel();

        public IEnumerable<AuthorBook> AuthorBooks { get { return context.AuthorBooks; } }

        public void DeleteAuthorBookByBookAndAuthorID(int AuthorID, int BookID)
        {
            context.AuthorBooks.RemoveRange(context.AuthorBooks.Where(abook => abook.BookID == BookID && abook.AuthorID == AuthorID));
            context.SaveChanges();
        }
        public void DeleteAllAuthorsForBook(int bookid)
        {
            context.AuthorBooks.RemoveRange(context.AuthorBooks.Where(abook => abook.BookID == bookid));
            context.SaveChanges();
        }
        public void AddAuthorBook(AuthorBook abook)
        {
            context.Database.ExecuteSqlCommand(
                        "exec AddAuthorBook @AuthorID, @BookID",
                        new SqlParameter("AuthorID", abook.AuthorID),
                        new SqlParameter("BookID", abook.BookID)
                    );
        }

        public void DeleteAuthorBook(int id)
        {
            context.Database.ExecuteSqlCommand(
                        "exec DeleteAuthorBook @ID",
                        new SqlParameter("ID", id)
                    );
        }
    }
}
