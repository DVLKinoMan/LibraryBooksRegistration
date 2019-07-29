using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryBooksRegistration.Domain.Entities;

namespace LibraryBooksRegistration.Domain.Abstract
{
    public interface IBookCategoryRepository
    {
        IEnumerable<BookCategory> BookCategories { get; }

        BookCategory GetBookCategoryByID(int ID);
        IEnumerable<BookCategory> GetCategoriesWhichHasNotSubCategories();

        void AddBookCategory(BookCategory BookCategory);
        void EditBookCategory(BookCategory BookCategory);
        void DeleteBookCategory(BookCategory BookCategory);
    }
}
