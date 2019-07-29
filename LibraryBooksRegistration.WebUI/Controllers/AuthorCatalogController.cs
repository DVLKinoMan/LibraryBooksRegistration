using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibraryBooksRegistration.Domain.Abstract;
using LibraryBooksRegistration.Domain.Concrete;
using LibraryBooksRegistration.Domain.Entities;

using LibraryBooksRegistration.WebUI.Models;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Globalization;

namespace LibraryBooksRegistration.WebUI.Controllers
{
    public class AuthorCatalogController : Controller
    {
        private IAuthorRepository AuthorsRepository = new DBAuthorRepository();

        // GET: AuthorCatalog
        public ActionResult Index()
        {
            ViewBag.NavBarActive = "AuthorCatalog";
            return View(AuthorsRepository.Authors.Select(a=> new AuthorViewModel
            {
                ID = a.ID,
                FirstName = a.FirstName,
                LastName = a.LastName,
                BirthDate = a.BirthDate
            }));
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddAuthor([DataSourceRequest] DataSourceRequest request, AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AuthorsRepository.AddAuthor(new Author
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDate = model.BirthDate
                    });
                    TempData["SuccessMessage"] = string.Format(model.FullName + " ავტორის დამატება განხორციელდა წარმატებულად");
                }
                catch (Exception exc)
                {
                    TempData["ErrorMessage"] = exc.Message;
                }
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditAuthor([DataSourceRequest] DataSourceRequest request, AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AuthorsRepository.EditAuthor(new Author
                    {
                        ID = model.ID,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDate = model.BirthDate
                    });
                    TempData["SuccessMessage"] = string.Format(model.FullName + " ავტორის რედაქტირება განხორციელდა წარმატებულად");
                }
                catch(Exception exc)
                {
                    TempData["ErrorMessage"] = exc.Message;
                }
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteAuthor([DataSourceRequest] DataSourceRequest request, AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AuthorsRepository.DeleteAuthor(new Author
                    {
                        ID=model.ID,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDate = model.BirthDate
                    });
                    TempData["SuccessMessage"] = string.Format(model.FullName + " ავტორის წაშლა განხორციელდა წარმატებულად");
                }
                catch (Exception exc)
                {
                    TempData["ErrorMessage"] = exc.Message;
                }
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}