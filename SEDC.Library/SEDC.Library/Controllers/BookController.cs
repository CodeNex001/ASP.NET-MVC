using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using SEDC.Library.Models;

namespace SEDC.Library.Controllers
{
    //[Route(template:"Kniga/[Action]")]
    //[Route(template: "Kniga")]
    public class BookController : Controller
    {
        //[Route(template: "Books")]
        public IActionResult Index()
        {
            List<Book> books = StaticDb.Books;
            return View(books);
        }

        //[Route(template: "Json")]
        public IActionResult JsonData()
        {
            Book book = new Book
            {
                Id = 1,
                Title = "Kasni Porasni"
            };
            return new JsonResult(book);
        }

        public IActionResult ListBooks() 
        {
            return RedirectToAction("Index");
        }

        public IActionResult BackToHome()
        {
            return RedirectToAction("Index", controllerName: "Home");
        }

        public IActionResult Empty()
        {
            return new EmptyResult();
        }

        public IActionResult Details(int? id)
        {
           if(id != null)
            {
                Book book = StaticDb.Books.FirstOrDefault(x => x.Id == id);
                return View(book);
            }
            return new EmptyResult();
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            Book book = new Book();
            return View(book);
        }
        [HttpPost]
        public IActionResult CreateBookPost(Book book)
        {
            StaticDb.BookID++;
            book.Id = StaticDb.BookID;
            StaticDb.Books.Add(book);
            return RedirectToAction("Index");
        }
    }
}
