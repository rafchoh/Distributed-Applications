using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private LibraryCopySystemDBContext context = new LibraryCopySystemDBContext();
        private GenericRepository<Book> bookRepository;        
        private GenericRepository<BookInCart> bicRepository;
        private GenericRepository<Cart> cartRepository;
        private GenericRepository<UserInfo> userInfoRepository;

        public GenericRepository<Book> BookRepository
        {
            get
            {

                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Book>(context);
                }
                return bookRepository;
            }
        }

        public GenericRepository<BookInCart> BookInCartRepository
        {
            get
            {

                if (this.bicRepository == null)
                {
                    this.bicRepository = new GenericRepository<BookInCart>(context);
                }
                return bicRepository;
            }
        }

        public GenericRepository<Cart> CartRepository
        {
            get
            {

                if (this.cartRepository == null)
                {
                    this.cartRepository = new GenericRepository<Cart>(context);
                }
                return cartRepository;
            }
        }

        public GenericRepository<UserInfo> UserInfoRepository
        {
            get
            {

                if (this.userInfoRepository == null)
                {
                    this.userInfoRepository = new GenericRepository<UserInfo>(context);
                }
                return userInfoRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
