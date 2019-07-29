using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibraryBooksRegistration.Domain.Abstract;
using LibraryBooksRegistration.Domain.Concrete;
using LibraryBooksRegistration.Domain.Entities;

using LibraryBooksRegistration.WebUI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace LibraryBooksRegistration.WebUI.Controllers
{
    public class BookCatalogController : Controller
    {
        private IBookRepository BooksRepository = new DBBookRepository();
        private IBookCategoryRepository BooksCategoryRepository = new DBBookCategoryRepository();
        private IAuthorRepository AuthorsRepository = new DBAuthorRepository();
        private IAuthorBookRepository AuthorBooksRepository = new DBAuthorBookRepository();

        // GET: BookCatalog
        public ActionResult Index()
        {
            ViewBag.NavBarActive = "BookCatalog";
            return View();
        }
        public ActionResult Books_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(BooksRepository.Books.Select(b => new BookViewModel
            {
                ID = b.ID,
                Name = b.Name,
                CategoryName = b.BookCategory.Name,
                PublishingHouse = b.PublishingHouse,
                PublishingDate = b.PublishingDate,
                BookAuthors = b.GetBookAuthorsString
            }).ToDataSourceResult(request));
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            ViewBag.CategoriesForBooks = BooksCategoryRepository.GetCategoriesWhichHasNotSubCategories().Select(cat => new SelectListItem { Value = cat.ID.ToString(), Text = cat.Name });
            ViewBag.Authors = AuthorsRepository.Authors.Select(a => new SelectListItem { Value = a.ID.ToString(), Text = a.FullName });
            return PartialView("Add_EditBook", new Add_EditBookViewModel { Book = new Book(), BookAuthors = new List<BookAuthorViewModel>() });
        }
        [HttpGet]
        public ActionResult EditBook(int bookid)
        {
            ViewBag.CategoriesForBooks = BooksCategoryRepository.GetCategoriesWhichHasNotSubCategories().Select(cat => new SelectListItem { Value = cat.ID.ToString(), Text = cat.Name });
            ViewBag.Authors = AuthorsRepository.Authors.Select(a => new SelectListItem { Value = a.ID.ToString(), Text = a.FullName });
            return PartialView("Add_EditBook", new Add_EditBookViewModel
            {
                Book = BooksRepository.GetBookByID(bookid),
                BookAuthors = AuthorBooksRepository.AuthorBooks.Where(abook=>abook.BookID==bookid).Select(abook =>
                new BookAuthorViewModel { AuthorID = abook.AuthorID, FullName = abook.Author.FullName }).ToList()
            });
        }
        [HttpPost]
        public ActionResult Add_EditBook(Add_EditBookViewModel model, string sbmbutton, int? DeleteAuthorId)
        {
            if (model.BookAuthors == null)
                model.BookAuthors = new List<BookAuthorViewModel>();
            if (DeleteAuthorId.HasValue)
            {
                model.BookAuthors.Remove(model.BookAuthors.Where(a => a.AuthorID == DeleteAuthorId).FirstOrDefault());
            }
            else
            {
                if (sbmbutton == "add_editbook")
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            if (model.Book.ID == 0)
                            {
                                int id = BooksRepository.AddBook(model.Book);
                                foreach (var abook in model.BookAuthors)
                                    AuthorBooksRepository.AddAuthorBook(new AuthorBook { AuthorID = abook.AuthorID, BookID = id });

                                //success message
                                ViewBag.SubmitedSuccessful = true;
                                TempData["SuccessMessage"] = model.Book.Name + " დაემატა წარმატებულად";
                            }
                            else
                            {
                                BooksRepository.EditBook(model.Book);
                                AuthorBooksRepository.DeleteAllAuthorsForBook(model.Book.ID);
                                foreach (var abook in model.BookAuthors)
                                    AuthorBooksRepository.AddAuthorBook(new AuthorBook { AuthorID = abook.AuthorID, BookID = model.Book.ID });

                                //success message
                                ViewBag.SubmitedSuccessful = true;
                                TempData["SuccessMessage"] = model.Book.Name + "-ის რედაქტირება განხორციელდა წარმატებულად";
                            }
                        }
                        catch (Exception exc)
                        {
                            TempData["ErrorMessage"] = exc.Message;
                        }
                    }
                if (sbmbutton == "AddAuthorForBook")
                {
                    if (!model.BookAuthors.Any(book => book.AuthorID == model.NewAuthorID))
                    {
                        model.BookAuthors.Add(new BookAuthorViewModel
                        {
                            FullName = AuthorsRepository.getAuthorByID(model.NewAuthorID).FullName,
                            AuthorID = model.NewAuthorID
                        });
                    }
                }
            }

            ViewBag.CategoriesForBooks = BooksCategoryRepository.GetCategoriesWhichHasNotSubCategories().Select(cat => new SelectListItem { Value = cat.ID.ToString(), Text = cat.Name }); ViewBag.CategoriesForBooks = BooksCategoryRepository.GetCategoriesWhichHasNotSubCategories().Select(cat => new SelectListItem { Value = cat.ID.ToString(), Text = cat.Name });
            ViewBag.Authors = AuthorsRepository.Authors.Select(a => new SelectListItem { Value = a.ID.ToString(), Text = a.FullName });
            return PartialView("Add_EditBook", model);
        }
        [HttpGet]
        public ActionResult DeleteBook(int bookid)
        {
            return PartialView("DeleteBook", BooksRepository.GetBookByID(bookid));
        }
        [HttpPost]
        public ActionResult DeleteBook(Book model)
        {
            try
            {
                AuthorBooksRepository.DeleteAllAuthorsForBook(model.ID);
                BooksRepository.DeleteBook(model);
                //success message
                ViewBag.SubmitedSuccessful = true;
                TempData["SuccessMessage"] = "წიგნის წაშლა განხორციელდა წარმატებულად";
            }
            catch (Exception exc)
            {
                TempData["ErrorMessage"] = exc.Message;
            }
            return PartialView("DeleteBook", model);
        }
    }
}