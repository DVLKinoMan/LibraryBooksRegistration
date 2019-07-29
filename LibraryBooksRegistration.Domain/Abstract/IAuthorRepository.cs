using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryBooksRegistration.Domain.Entities;

namespace LibraryBooksRegistration.Domain.Abstract
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> Authors { get; }

        Author getAuthorByID(int authorID);
        void AddAuthor(Author author);
        void EditAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
