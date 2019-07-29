using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryBooksRegistration.Domain.Abstract;
using LibraryBooksRegistration.Domain.Entities;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace LibraryBooksRegistration.Domain.Concrete
{
    public class DBAuthorRepository:IAuthorRepository
    {
        private LibraryBooksRegistrationDatabaseModel context = new LibraryBooksRegistrationDatabaseModel();

        public IEnumerable<Author> Authors { get { return context.Authors; } }

        public Author getAuthorByID(int authorID)
        {
            return context.Authors.Where(a => a.ID == authorID).FirstOrDefault();
        }
        public void AddAuthor(Author author)
        {
            context.Database.ExecuteSqlCommand(
                        "exec AddAuthor @FirstName, @LastName, @BirthDate",
                        new SqlParameter("FirstName", author.FirstName),
                        new SqlParameter("LastName", author.LastName),
                        new SqlParameter("BirthDate", author.BirthDate)
                    );
        }
        public void EditAuthor(Author author)
        {
            context.Database.ExecuteSqlCommand(
                    "exec EditAuthor @ID, @FirstName, @LastName, @BirthDate",
                    new SqlParameter("ID", author.ID),
                    new SqlParameter("FirstName", author.FirstName),
                    new SqlParameter("LastName", author.LastName),
                    new SqlParameter("BirthDate", author.BirthDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
                );
        }
        public void DeleteAuthor(Author author)
        {
            context.Database.ExecuteSqlCommand(
                "exec DeleteAuthor @ID",
                new SqlParameter("ID", author.ID)
                );
        }
    }
}
