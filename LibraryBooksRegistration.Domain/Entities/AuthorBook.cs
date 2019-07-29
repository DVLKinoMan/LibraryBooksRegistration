namespace LibraryBooksRegistration.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AuthorBook
    {
        public int ID { get; set; }

        public int AuthorID { get; set; }

        public int BookID { get; set; }

        public virtual Author Author { get; set; }

        public virtual Book Book { get; set; }
    }
}
