using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryBooksRegistration.WebUI.Models
{
    public class AuthorViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "ავტორის სახელი აუცილებელი პარამეტრია")]
        [StringLength(maximumLength: 50, ErrorMessage = "ავტორის სახელის სიგრძე არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        [Display(Name = "სახელი")]
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

        public string FullName { get { return FirstName + " " + LastName; } }
    }
}