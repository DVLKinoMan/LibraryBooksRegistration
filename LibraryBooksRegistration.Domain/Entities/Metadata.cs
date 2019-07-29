using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksRegistration.Domain.Entities
{
    public class AuthorMetadata
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="ავტორის სახელი აუცილებელი პარამეტრია" )]
        [StringLength(maximumLength:50,ErrorMessage ="ავტორის სახელის სიგრძე არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        [Display(Name ="სახელი")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "ავტორის გვარი აუცილებელი პარამეტრია")]
        [StringLength(maximumLength: 50, ErrorMessage = "ავტორის გვარის სიგრძე არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        [Display(Name = "გვარი")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "ავტორის დაბადების თარიღი აუცილებელი პარამეტრია")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "დაბადების თარიღი")]
        public System.DateTime BirthDate { get; set; }
        
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
    public class AuthorBookMetadata
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
    public class BookMetadata
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "წიგნის დასახელება აუცილებელი ველია")]
        [Display(Name = "დასახელება")]
        [StringLength(maximumLength: 50,ErrorMessage ="წიგნის დასახელების სიგრძე არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string Name { get; set; }
        [Required(ErrorMessage = "წიგნის კატეგორია აუცილებელი ველია")]
        [Display(Name="კატეგორია")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="წიგნის გამომცემლობა აუცილებელი ველია")]
        [Display(Name = "წიგნის გამომცემლობა")]
        [StringLength(maximumLength: 50, ErrorMessage = "წიგნის გამომცემლობის სიგრძე არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string PublishingHouse { get; set; }
        [Display(Name = "წიგნის გამოცემის თარიღი")]
        [Required(ErrorMessage = "წიგნის გამოცემის თარიღი აუცილებელი ველია")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime PublishingDate { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual BookCategory BookCategory { get; set; }
    }
    public class BookCategoryMetadata
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="წიგნის კატეგორიის სახელი აუცილებელი ველია")]
        [StringLength(maximumLength: 50, ErrorMessage = "წიგნის კატეგორიის სახელის სიგრძე არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        [Display(Name="დასახელება")]
        public string Name { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage ="წიგნის კატეგორიის აღწერის ველის სიგრძე არ უნდა აღემატებოდეს 200 სიმბოლოს")]
        [Display(Name = "აღწერა")]
        public string Description { get; set; }

        [Display(Name = "წიგნების რაოდენობა")]
        public int? BooksQuantity { get; set; }

        [Display(Name = "მშობელი კატეგორიის იდენტიფიკატორი")]
        public int? ParentCategoryID { get; set; }
        
        public virtual ICollection<BookCategory> BookCategories1 { get; set; }

        [Display(Name = "მშობელი კატეგორია")]
        public virtual BookCategory BookCategory1 { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
