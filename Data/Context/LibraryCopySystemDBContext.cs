using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class LibraryCopySystemDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<BookInCart> BooksInCart { get; set; }

    }
}
