using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public long ISBN { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }
        public string Genre { get; set; }
        public DateTime? DateORelease { get; set; }

        public decimal Price { get; set; }
    }
}
