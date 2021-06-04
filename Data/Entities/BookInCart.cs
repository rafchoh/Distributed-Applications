using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BookInCart : BaseEntity
    {
        public int BookId { get; set; }
        public int CartId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
    }
}