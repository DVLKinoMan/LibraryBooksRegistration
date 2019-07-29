using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryBooksRegistration.WebUI.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        [Display(Name = "წიგნის დასახელება")]
        public string Name { get; set; }
        [Display(Name = "წიგნის კატეგორია")]
        public string CategoryName { get; set; }
        [Display(Name = "წიგნის გამომცემლობა")]
        public string PublishingHouse { get; set; }
        [Display(Name = "წიგნის გამოცემის თარიღი")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime PublishingDate { get; set; }
        [Display(Name="წიგნის ავტორები")]
        public string BookAuthors { get; set; }
    }
}