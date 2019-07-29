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
    public class DBBookCategoryRepository : IBookCategoryRepository
    {
        private LibraryBooksRegistrationDatabaseModel context = new LibraryBooksRegistrationDatabaseModel();

        public IEnumerable<BookCategory> BookCategories { get { return context.BookCategories; } }

        public BookCategory GetBookCategoryByID(int ID)
        {
            return context.BookCategories.Where(cat => cat.ID == ID).FirstOrDefault();
        }
        public IEnumerable<BookCategory> GetCategoriesWhichHasNotSubCategories()
        {
            return context.BookCategories.Where(cat => !cat.BookCategories1.Any());
        }
        public void AddBookCategory(BookCategory BookCategory)
        {
            context.Database.ExecuteSqlCommand(
                        "exec AddBookCategory @Name, @Description, @ParentCategoryID",
                        new SqlParameter("Name", BookCategory.Name),
                        new SqlParameter("Description", (object)BookCategory.Description ?? DBNull.Value),
                        new SqlParameter("ParentCategoryID", (object)BookCategory.ParentCategoryID ?? DBNull.Value)
                    );
        }
        public void EditBookCategory(BookCategory BookCategory)
        {
            context.Database.ExecuteSqlCommand(
                        "exec EditBookCategory @ID, @Name, @Description",
                        new SqlParameter("ID", BookCategory.ID),
                        new SqlParameter("Name", BookCategory.Name),
                        new SqlParameter("Description", (object)BookCategory.Description ?? DBNull.Value)
                    );
        }
        public void DeleteBookCategory(BookCategory BookCategory)
        {
            context.Database.ExecuteSqlCommand(
                        "exec DeleteBookCategory @ID",
                        new SqlParameter("ID", BookCategory.ID)
                    );
        }
    }
}
