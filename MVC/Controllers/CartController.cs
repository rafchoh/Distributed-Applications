using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
    {
        public class CartController : Controller
        {
            // GET: Cart
            public ActionResult Index()
            {
                List<CartVM> cartsVM = new List<CartVM>();

                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    foreach (var item in service.GetCart())
                    {
                        cartsVM.Add(new CartVM(item));
                    }
                }

                return View(cartsVM);
            }

            // GET: Cart/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Cart/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(CartVM cartVM)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                        {
                            CartDTO cartDTO = new CartDTO
                            {
                                ISBN = cartVM.ISBN,
                                Author = cartVM.Author,
                                BookName = cartVM.BookName,
                                Price = cartVM.Price
                            };
                            service.PostCart(cartDTO);
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
                    service.DeleteCart(id);
                }
                return RedirectToAction("Index");
            }
        }
    }