using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Implementations;

namespace ApplicationService.Implementations
{
    public class BookManagementService
    {
        private LibraryCopySystemDBContext context = new LibraryCopySystemDBContext();
        //
        //
        //
        public List<BookDTO> Get()
        {
            List<BookDTO> booksDto = new List<BookDTO>();

            //foreach (var item in context.Books.ToList())
            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.BookRepository.Get()) 
                { 
                    booksDto.Add(new BookDTO
                    {
                        Id = item.Id,
                        ISBN = item.ISBN,
                        Author = item.Author,
                        BookName = item.BookName,
                        Genre = item.Genre,
                        DateORelease = item.DateORelease,
                        Price = item.Price
                    });
                }
            }

            return booksDto;
        }
        //
        //
        public bool Save(BookDTO bookDto)
        {
            Book Book = new Book
            {
                ISBN = bookDto.ISBN,
                Author = bookDto.Author,
                BookName = bookDto.BookName,
                Genre = bookDto.Genre,
                DateORelease = bookDto.DateORelease,
                Price = bookDto.Price
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.BookRepository.Insert(Book);

                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        //
        public bool Update(BookDTO bookDTO)
        {
            Book Book = new Book
            {
                Id = bookDTO.Id,
                ISBN = bookDTO.ISBN,
                Author = bookDTO.Author,
                BookName = bookDTO.BookName,
                Genre = bookDTO.Genre,
                DateORelease = bookDTO.DateORelease,
                Price = bookDTO.Price
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.BookRepository.Update(Book);

                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        //
        public List<BookDTO> GetBookBySearch(string search)
        {
            List<BookDTO> booksDto = new List<BookDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.BookRepository.Get())
                {
                    if (item.Id != 0 && item.BookName != null)
                    {
                        if (search == item.BookName) 
                        {
                            booksDto.Add(new BookDTO
                            {
                                Id = item.Id,
                                ISBN = item.ISBN,
                                Author = item.Author,
                                BookName = item.BookName,
                                Genre = item.Genre,
                                DateORelease = item.DateORelease,
                                Price = item.Price
                            });
                        }
                    }
                    else
                    {
                        booksDto.Add(new BookDTO
                        {
                            Id = item.Id,
                            ISBN = item.ISBN,
                            Author = item.Author,
                            BookName = item.BookName,
                            Genre = item.Genre,
                            DateORelease = item.DateORelease,
                            Price = item.Price
                        });
                    }
                }
            }

            return booksDto;
        }
        //
        //
        public BookDTO GetBookById(int id)
        {
            BookDTO bookDto = new BookDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Book book = unitOfWork.BookRepository.GetByID(id);
                bookDto = new BookDTO
                {
                    Id = book.Id,
                    ISBN = book.ISBN,
                    Author = book.Author,
                    BookName = book.BookName,
                    Genre = book.Genre,
                    DateORelease = book.DateORelease,
                    Price = book.Price
                };
            }

            return bookDto;
        }
        //
        //
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Book book = unitOfWork.BookRepository.GetByID(id);
                    unitOfWork.BookRepository.Delete(book);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        //
        public List<BookDTO> GetBooksToCart(int? id)
        {
            List<BookDTO> booksDto = new List<BookDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.BookRepository.Get())
                {
                    booksDto.Add(new BookDTO
                    {
                        Id = item.Id,
                        ISBN = item.ISBN,
                        Author = item.Author,
                        BookName = item.BookName,
                        //Genre = item.Genre,
                        //DateORelease = item.DateORelease,                    
                        Price = item.Price
                    });
                }
            }

            // get all BookInCart where CartId is id
            List<BookInCartDTO> take = new List<BookInCartDTO>();

            CartDTO cartDto = new CartDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Cart cart = unitOfWork.CartRepository.GetByID(id);
                cartDto = new CartDTO
                {
                    Id = cart.Id,
                    ISBN = cart.ISBN,
                    Author = cart.Author,
                    BookName = cart.BookName,
                    Price = cart.Price
                };
            }




            return booksDto;
        }
    }
}
