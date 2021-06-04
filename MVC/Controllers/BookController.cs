using MVC.ViewModels;
using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index(string search)
        {
            List<BookVM> booksVM = new List<BookVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                if (!String.IsNullOrEmpty(search))
                {
                    foreach (var item in service.GetBookBySearch(search))
                    {
                        booksVM.Add(new BookVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetBooks())
                    {
                        booksVM.Add(new BookVM(item));
                    }
                }
            }

            return View(booksVM);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookVM bookVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        BookDTO bookDto = new BookDTO
                        {
                            ISBN = bookVM.ISBN,
                            Author = bookVM.Author,
                            BookName = bookVM.BookName,
                            Genre = bookVM.Genre,
                            DateORelease = bookVM.DateORelease,
                            Price = bookVM.Price
                        };
                        service.PostBook(bookDto);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit
        public ActionResult Edit(int id)
        {
            BookVM bookVM = new BookVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var bookDTO = service.GetBookByID(id);
                bookVM = new BookVM(bookDTO);
            }

            return View(bookVM);
        }

        // POST: Books/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookVM bookVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        BookDTO bookDto = new BookDTO
                        {
                            Id = bookVM.Id,
                            ISBN = bookVM.ISBN,
                            Author = bookVM.Author,
                            BookName = bookVM.BookName,
                            Genre = bookVM.Genre,
                            DateORelease = bookVM.DateORelease,                            
                            Price = bookVM.Price
                        };

                        service.PutBook(bookDto);                                                
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteBook(id);
            }
            return RedirectToAction("Index");
        }

    }
}