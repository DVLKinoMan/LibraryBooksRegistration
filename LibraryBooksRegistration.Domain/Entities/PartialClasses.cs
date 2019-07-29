using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksRegistration.Domain.Entities
{
    [MetadataType(typeof(AuthorMetadata))]
    public partial class Author
    {
        public string FullName { get { return FirstName + " " + LastName; } }
    }
    [MetadataType(typeof(BookMetadata))]
    public partial class Book
    {
        public string GetBookAuthorsString { get { return (this.AuthorBooks!= null && this.AuthorBooks.Count!=0) ? this.AuthorBooks.Select(a => a.Author.FullName).Aggregate((current, next) => current + ", " + next) : ""; } }
    }
    [MetadataType(typeof(BookCategoryMetadata))]
    public partial class BookCategory
    {
    }
    [MetadataType(typeof(AuthorBookMetadata))]
    public partial class AuthorBook
    {
    }
}
