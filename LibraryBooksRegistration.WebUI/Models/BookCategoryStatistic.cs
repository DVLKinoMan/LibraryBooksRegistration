using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryBooksRegistration.WebUI.Models
{
    public class BookCategoryStatistic
    {
        public int ID { get; set; }
        [Display(Name ="კატეგორიის სრული მისამართი")]
        public string path { get; set; }
        [Display(Name = "კატეგორიაში წიგნების რაოდენობა")]
        public int BooksQuantity { get; set; }
    }
}