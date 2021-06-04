using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class BookInCartDTO
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public int CartId { get; set; }
    }
}
