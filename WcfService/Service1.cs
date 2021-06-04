using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        // Book
        private BookManagementService bookService = new BookManagementService();

        public List<BookDTO> GetBooks()
        {
            return bookService.Get();
        }

        public List<BookDTO> GetBookBySearch(string search)
        {
            return bookService.GetBookBySearch(search);
        }

        public BookDTO GetBookByID(int id)
        {
            return bookService.GetBookById(id);
        }

        public string PutBook(BookDTO bookDTO)
        {
            if (!bookService.Update(bookDTO))
                return "Book is not updated";

            return "Book is updated";
        }

        public string PostBook(BookDTO bookDto)
        {
            if (!bookService.Save(bookDto))
                return "Book is not saved!";

            return "Book is saved!";
        }

        public string DeleteBook(int id)
        {
            if (!bookService.Delete(id))
                return "Book is not deleted!";

            return "Book is deleted!";
        }


        // User Info
        private UserInfoManagementService userService = new UserInfoManagementService();

        public List<UserInfoDTO> GetUserInfo()
        {
            return userService.Get();
        }

        public UserInfoDTO GetUserByID(int id)
        {
            return userService.GetUserById(id);
        }

        public string PutUserInfo(UserInfoDTO userInfoDTO)
        {
            if (!userService.Save(userInfoDTO))
                return "User is not updated!";

            return "User is updated!";
        }
        
        public string PostUserInfo(UserInfoDTO userInfoDto)
        {
            if (!userService.Save(userInfoDto))
                return "User is not saved!";

            return "User is saved!";
        }

        public string DeleteUserInfo(int id)
        {
            if (!userService.Delete(id))
                return "User is not deleted!";

            return "User is deleted!";
        }


        // Cart
        private CartManagementService cartService = new CartManagementService();

        public List<CartDTO> GetCart()
        {
            return cartService.Get();
        }

        public CartDTO GetCartByID(int id)
        {
            return cartService.GetCartById(id);
        }

        public string PutCart(CartDTO cartDto)
        {
            if (!cartService.Save(cartDto))
                return "Cart is not updated";

            return "Cart is updated";
        }

        public string PostCart(CartDTO cartDto)
        {
            if (!cartService.Save(cartDto))
                return "Cart is not inserted!";

            return "Cart is inserted!";
        }

        public string DeleteCart(int id)
        {
            if (!cartService.Delete(id))
                return "Cart is not deleted!";

            return "Cart is deleted!";
        }
    }
}
