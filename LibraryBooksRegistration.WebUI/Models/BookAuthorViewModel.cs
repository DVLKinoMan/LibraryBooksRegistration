using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryBooksRegistration.WebUI.Models
{
    public class BookAuthorViewModel
    {
        public int AuthorID { get; set; }
        [Display(Name ="ავტორის სრული სახელი")]
        public string FullName { get; set; }
    }
}