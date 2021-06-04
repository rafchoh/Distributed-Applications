using ApplicationService.DTOs;
//using MVC.SOAPService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }

        [Required]
        public long ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public string Genre { get; set; }
        [Required]
        [Display(Name = "Date of release")]
        [DataType(DataType.Date)]
        public DateTime? DateORelease { get; set; }

        [Required]
        public decimal Price { get; set; }

        public BookVM() { }

        public BookVM(BookDTO bookDTO)
        {
            Id = bookDTO.Id;
            ISBN = bookDTO.ISBN;
            Author = bookDTO.Author;
            BookName = bookDTO.BookName;
            Genre = bookDTO.Genre;
            DateORelease = bookDTO.DateORelease;
            Price = bookDTO.Price;
        }
    }
}