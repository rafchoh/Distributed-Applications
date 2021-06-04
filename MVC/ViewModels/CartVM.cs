using ApplicationService.DTOs;
//using MVC.SOAPService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class CartVM
    {
        public int Id { get; set; }

        public int UserInfoId { get; set; }

        public long ISBN { get; set; }
        public string Author { get; set; }
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public decimal Price { get; set; }

        public DateTime DateOAdding { get; set; }

        public CartVM() { }

        public CartVM(CartDTO cartDTO)
        {
            Id = cartDTO.Id;
            UserInfoId = cartDTO.UserInfoId;
            ISBN = cartDTO.ISBN;
            Author = cartDTO.Author;
            BookName = cartDTO.BookName;
            Price = cartDTO.Price;
            DateOAdding = cartDTO.DateOAdding;
        }
    }
}