namespace LibraryBooksRegistration.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibraryBooksRegistrationDatabaseModel : DbContext
    {
        public LibraryBooksRegistrationDatabaseModel()
            : base("name=LibraryBooksRegistrationDatabaseModel")
        {
        }

        public virtual DbSet<AuthorBook> AuthorBooks { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.AuthorBooks)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookCategory>()
                .HasMany(e => e.BookCategories1)
                .WithOptional(e => e.BookCategory1)
                .HasForeignKey(e => e.ParentCategoryID);

            modelBuilder.Entity<BookCategory>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.BookCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.AuthorBooks)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);
        }
        //public virtual void AddAuthor(string firstName, string lastName, Nullable<System.DateTime> birthDate)
        //{
        //    var firstNameParameter = firstName != null ?
        //        new ObjectParameter("FirstName", firstName) :
        //        new ObjectParameter("FirstName", typeof(string));

        //    var lastNameParameter = lastName != null ?
        //        new ObjectParameter("LastName", lastName) :
        //        new ObjectParameter("LastName", typeof(string));

        //    var birthDateParameter = birthDate.HasValue ?
        //        new ObjectParameter("BirthDate", birthDate) :
        //        new ObjectParameter("BirthDate", typeof(System.DateTime));

        //    this.Database.SqlQuery<Author>("AddAuthor", firstName, lastName, birthDate);
        //}

        //public virtual int AddAuthorBook(Nullable<int> authorID, Nullable<int> bookID)
        //{
        //    var authorIDParameter = authorID.HasValue ?
        //        new ObjectParameter("AuthorID", authorID) :
        //        new ObjectParameter("AuthorID", typeof(int));

        //    var bookIDParameter = bookID.HasValue ?
        //        new ObjectParameter("BookID", bookID) :
        //        new ObjectParameter("BookID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddAuthorBook", authorIDParameter, bookIDParameter);
        //}

        //public virtual int AddBook(string name, Nullable<int> categoryID, string publishingHouse, Nullable<System.DateTime> publishingDate)
        //{
        //    var nameParameter = name != null ?
        //        new ObjectParameter("Name", name) :
        //        new ObjectParameter("Name", typeof(string));

        //    var categoryIDParameter = categoryID.HasValue ?
        //        new ObjectParameter("CategoryID", categoryID) :
        //        new ObjectParameter("CategoryID", typeof(int));

        //    var publishingHouseParameter = publishingHouse != null ?
        //        new ObjectParameter("PublishingHouse", publishingHouse) :
        //        new ObjectParameter("PublishingHouse", typeof(string));

        //    var publishingDateParameter = publishingDate.HasValue ?
        //        new ObjectParameter("PublishingDate", publishingDate) :
        //        new ObjectParameter("PublishingDate", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddBook", nameParameter, categoryIDParameter, publishingHouseParameter, publishingDateParameter);
        //}

        //public virtual int AddBookCategory(string name, string description)
        //{
        //    var nameParameter = name != null ?
        //        new ObjectParameter("Name", name) :
        //        new ObjectParameter("Name", typeof(string));

        //    var descriptionParameter = description != null ?
        //        new ObjectParameter("Description", description) :
        //        new ObjectParameter("Description", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddBookCategory", nameParameter, descriptionParameter);
        //}

        //public virtual int AddBookCategorySubCategory(Nullable<int> categoryID, Nullable<int> subCategoryID)
        //{
        //    var categoryIDParameter = categoryID.HasValue ?
        //        new ObjectParameter("CategoryID", categoryID) :
        //        new ObjectParameter("CategoryID", typeof(int));

        //    var subCategoryIDParameter = subCategoryID.HasValue ?
        //        new ObjectParameter("SubCategoryID", subCategoryID) :
        //        new ObjectParameter("SubCategoryID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddBookCategorySubCategory", categoryIDParameter, subCategoryIDParameter);
        //}

        //public virtual int DeleteAuthor(Nullable<int> iD)
        //{
        //    var iDParameter = iD.HasValue ?
        //        new ObjectParameter("ID", iD) :
        //        new ObjectParameter("ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteAuthor", iDParameter);
        //}

        //public virtual int DeleteAuthorBook(Nullable<int> iD)
        //{
        //    var iDParameter = iD.HasValue ?
        //        new ObjectParameter("ID", iD) :
        //        new ObjectParameter("ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteAuthorBook", iDParameter);
        //}

        //public virtual int DeleteBook(Nullable<int> iD)
        //{
        //    var iDParameter = iD.HasValue ?
        //        new ObjectParameter("ID", iD) :
        //        new ObjectParameter("ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteBook", iDParameter);
        //}

        //public virtual int DeleteBookCategory(Nullable<int> iD)
        //{
        //    var iDParameter = iD.HasValue ?
        //        new ObjectParameter("ID", iD) :
        //        new ObjectParameter("ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteBookCategory", iDParameter);
        //}

        //public virtual int DeleteBookCategorySubCategory(Nullable<int> iD)
        //{
        //    var iDParameter = iD.HasValue ?
        //        new ObjectParameter("ID", iD) :
        //        new ObjectParameter("ID", typeof(int));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteBookCategorySubCategory", iDParameter);
        //}

        //public virtual int EditAuthor(Nullable<int> iD, string firstName, string lastName, Nullable<System.DateTime> birthDate)
        //{
        //    var iDParameter = iD.HasValue ?
        //        new ObjectParameter("ID", iD) :
        //        new ObjectParameter("ID", typeof(int));

        //    var firstNameParameter = firstName != null ?
        //        new ObjectParameter("FirstName", firstName) :
        //        new ObjectParameter("FirstName", typeof(string));

        //    var lastNameParameter = lastName != null ?
        //        new ObjectParameter("LastName", lastName) :
        //        new ObjectParameter("LastName", typeof(string));

        //    var birthDateParameter = birthDate.HasValue ?
        //        new ObjectParameter("BirthDate", birthDate) :
        //        new ObjectParameter("BirthDate", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditAuthor", iDParameter, firstNameParameter, lastNameParameter, birthDateParameter);
        //}

        //public virtual int EditBook(Nullable<int> iD, string name, Nullable<int> categoryID, string publishingHouse, Nullable<System.DateTime> publishingDate)
        //{
        //    var iDParameter = iD.HasValue ?
        //        new ObjectParameter("ID", iD) :
        //        new ObjectParameter("ID", typeof(int));

        //    var nameParameter = name != null ?
        //        new ObjectParameter("Name", name) :
        //        new ObjectParameter("Name", typeof(string));

        //    var categoryIDParameter = categoryID.HasValue ?
        //        new ObjectParameter("CategoryID", categoryID) :
        //        new ObjectParameter("CategoryID", typeof(int));

        //    var publishingHouseParameter = publishingHouse != null ?
        //        new ObjectParameter("PublishingHouse", publishingHouse) :
        //        new ObjectParameter("PublishingHouse", typeof(string));

        //    var publishingDateParameter = publishingDate.HasValue ?
        //        new ObjectParameter("PublishingDate", publishingDate) :
        //        new ObjectParameter("PublishingDate", typeof(System.DateTime));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditBook", iDParameter, nameParameter, categoryIDParameter, publishingHouseParameter, publishingDateParameter);
        //}

        //public virtual int EditBookCategory(Nullable<int> iD, string name, string description)
        //{
        //    var iDParameter = iD.HasValue ?
        //        new ObjectParameter("ID", iD) :
        //        new ObjectParameter("ID", typeof(int));

        //    var nameParameter = name != null ?
        //        new ObjectParameter("Name", name) :
        //        new ObjectParameter("Name", typeof(string));

        //    var descriptionParameter = description != null ?
        //        new ObjectParameter("Description", description) :
        //        new ObjectParameter("Description", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditBookCategory", iDParameter, nameParameter, descriptionParameter);
        //}
    }
}
