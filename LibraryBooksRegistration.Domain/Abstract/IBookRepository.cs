using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryBooksRegistration.Domain.Entities;

namespace LibraryBooksRegistration.Domain.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }

        Book GetBookByID(int bookid);
        int AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(Book book);
    }
}
