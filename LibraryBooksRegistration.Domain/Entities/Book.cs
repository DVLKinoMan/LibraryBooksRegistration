namespace LibraryBooksRegistration.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            AuthorBooks = new HashSet<AuthorBook>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string PublishingHouse { get; set; }

        [Column(TypeName = "date")]
        public DateTime PublishingDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

        public virtual BookCategory BookCategory { get; set; }
    }
}
