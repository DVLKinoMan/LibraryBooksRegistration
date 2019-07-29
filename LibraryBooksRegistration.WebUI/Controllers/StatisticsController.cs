using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibraryBooksRegistration.Domain.Abstract;
using LibraryBooksRegistration.Domain.Concrete;
using LibraryBooksRegistration.Domain.Entities;

using LibraryBooksRegistration.WebUI.Models;

namespace LibraryBooksRegistration.WebUI.Controllers
{
    public class StatisticsController : Controller
    {
        private IBookCategoryRepository BookCategoriesRepository = new DBBookCategoryRepository();
        // GET: Statistics
        public ActionResult Index()
        {
            List<BookCategoryStatistic> categoryStats = new List<Models.BookCategoryStatistic>();
            int AllBooksQuantity = 0;
            foreach(var BaseCategory in BookCategoriesRepository.BookCategories.Where(c => c.ParentCategoryID == null))
            {
                //Get Base Category
                var basecat = new BookCategoryStatistic { ID=BaseCategory.ID, path = BaseCategory.Name, BooksQuantity = (int)BaseCategory.BooksQuantity };
                categoryStats.Add(basecat);

                var NodesOfCateogries = new List<BookCategory>();
                NodesOfCateogries.Add(BaseCategory);
                while (NodesOfCateogries.Count() != 0)
                {
                    var ParentNode = NodesOfCateogries.First();
                    //For Each child Category of FirstNode
                    foreach (var ChildNode in ParentNode.BookCategories1)
                    {
                        categoryStats.Add(new BookCategoryStatistic { ID=ChildNode.ID, path = categoryStats.Where(stat=>stat.ID==ParentNode.ID).First().path+"\\"+ChildNode.Name, BooksQuantity = (int)ChildNode.BooksQuantity });
                        NodesOfCateogries.Add(ChildNode);
                    }
                    NodesOfCateogries.Remove(ParentNode);
                }
                AllBooksQuantity += basecat.BooksQuantity;
            }
            categoryStats.Add(new BookCategoryStatistic { path = "სულ", BooksQuantity = AllBooksQuantity });
            ViewBag.NavBarActive = "Statistics";
            return View(categoryStats);
        }
    }
}