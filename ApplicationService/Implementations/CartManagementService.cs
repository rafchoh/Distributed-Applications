using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class CartManagementService
    {
        private LibraryCopySystemDBContext context = new LibraryCopySystemDBContext();
        //
        //
        //
        public List<CartDTO> Get()
        {
            List<CartDTO> cartsDto = new List<CartDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CartRepository.Get())
                {
                    cartsDto.Add(new CartDTO
                    {
                        Id = item.Id,
                        UserInfoId = item.UserInfoId,
                        ISBN = item.ISBN,
                        Author = item.Author,
                        BookName = item.BookName,
                        Price = item.Price,
                        DateOAdding = item.DateOAdding
                    });
                }
            }
            return cartsDto;
        }
        //
        //
        public CartDTO GetCartById(int id)
        {
            CartDTO cartDto = new CartDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Cart cart = unitOfWork.CartRepository.GetByID(id);
                cartDto = new CartDTO
                {
                    Id = cart.Id,
                    UserInfoId = cart.UserInfoId,
                    ISBN = cart.ISBN,
                    Author = cart.Author,
                    BookName = cart.BookName,
                    Price = cart.Price,
                    DateOAdding = cart.DateOAdding
                };
            }

            return cartDto;
        }
        //
        //
        public bool Save(CartDTO cartDto)
        {
            Cart Cart = new Cart
            {
                UserInfoId = cartDto.UserInfoId,
                ISBN = cartDto.ISBN,
                Author = cartDto.Author,
                Price = cartDto.Price,
                BookName = cartDto.BookName,
                DateOAdding = cartDto.DateOAdding
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.CartRepository.Insert(Cart);
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
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Cart Cart = unitOfWork.CartRepository.GetByID(id);
                    unitOfWork.CartRepository.Delete(Cart);
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
