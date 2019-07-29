using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryBooksRegistration.Domain.Entities;

namespace LibraryBooksRegistration.Domain.Abstract
{
    public interface IAuthorBookRepository
    {
        IEnumerable<AuthorBook> AuthorBooks { get; }

        void DeleteAuthorBookByBookAndAuthorID(int AuthorID, int BookID);
        void DeleteAllAuthorsForBook(int bookid);
        void AddAuthorBook(AuthorBook abook);
        void DeleteAuthorBook(int id);
    }
}
