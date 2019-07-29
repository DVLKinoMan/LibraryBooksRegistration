using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibraryBooksRegistration.Domain.Abstract;
using LibraryBooksRegistration.Domain.Concrete;
using LibraryBooksRegistration.Domain.Entities;

namespace LibraryBooksRegistration.WebUI.Controllers
{
    public class BookCategoryCatalogController : Controller
    {
        private IBookCategoryRepository BookCategoryRepository = new DBBookCategoryRepository();

        // GET: CategoryCatalog
        public ActionResult Index()
        {
            ViewBag.NavBarActive = "BookCategoryCatalog";
            return View();
        }

        public JsonResult ReadCategories(int? CategoryID)
        {
            var BookCategories = BookCategoryRepository.BookCategories
                .Where(cat => (CategoryID.HasValue && (cat.ParentCategoryID == CategoryID || (CategoryID==-1 && cat.ParentCategoryID == null))));

            var BookCategoriesResult = BookCategories.Select(cat => new
            {
                CategoryID = cat.ID,
                Name = cat.Name,
                Description = cat.Description,
                HasChildren = cat.BookCategories1.Any()
            }).ToList();

            if (!CategoryID.HasValue)
                BookCategoriesResult.Add(new
                {
                    CategoryID = -1,
                    Name = "კატეგორიები",
                    Description = "",
                    HasChildren = BookCategoryRepository.BookCategories.Any()
                });

            return this.Json(BookCategoriesResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddBookCategory(int? CategoryID)
        {
            BookCategory model = new BookCategory() { ParentCategoryID = CategoryID };
            return PartialView("AddBookCategory",model);
        }
        [HttpPost]
        public ActionResult AddBookCategory(BookCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BookCategoryRepository.AddBookCategory(model);
                    //success message
                    ViewBag.SubmitedSuccessful = true;
                    TempData["SuccessMessage"] = model.Name + " დაემატა წარმატებულად";
                }
                catch(Exception exc)
                {
                    TempData["ErrorMessage"] = exc.Message;
                }
            }
            return PartialView("AddBookCategory", model);
        }
        
        [HttpGet]
        public ActionResult EditBookCategory(int CategoryID)
        {
            BookCategory model = BookCategoryRepository.GetBookCategoryByID(CategoryID);
            return PartialView("EditBookCategory", model);
        }
        [HttpPost]
        public ActionResult EditBookCategory(BookCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BookCategoryRepository.EditBookCategory(model);
                    //success message
                    ViewBag.SubmitedSuccessful = true;
                    TempData["SuccessMessage"] = model.Name + " რედაქტირება განხორციელდა წარმატებულად";
                }
                catch (Exception exc)
                {
                    TempData["ErrorMessage"] = exc.Message;
                }
            }
            return PartialView("EditBookCategory", model);
        }

        [HttpGet]
        public ActionResult DeleteBookCategory(int CategoryID)
        {
            return PartialView("DeleteBookCategory", new BookCategory { ID = CategoryID });
        }
        [HttpPost]
        public ActionResult DeleteBookCategory(BookCategory model)
        {
            try
            {
                BookCategoryRepository.DeleteBookCategory(model);
                //success message
                ViewBag.SubmitedSuccessful = true;
                TempData["SuccessMessage"] = "კატეგორიის წაშლა განხორციელდა წარმატებულად";
            }
            catch (Exception exc)
            {
                TempData["ErrorMessage"] = exc.Message;
            }
            return PartialView("DeleteBookCategory", model);
        }
    }
}