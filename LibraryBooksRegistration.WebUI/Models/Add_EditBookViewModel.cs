using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibraryBooksRegistration.Domain.Entities;

namespace LibraryBooksRegistration.WebUI.Models
{
    public class Add_EditBookViewModel
    {
        public Book Book { get; set; }
        public IList<BookAuthorViewModel> BookAuthors { get; set; }
        public int NewAuthorID { get; set; }
    }
}