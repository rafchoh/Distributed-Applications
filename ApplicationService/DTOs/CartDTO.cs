using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }

        public int UserInfoId { get; set; }

        public long ISBN { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }

        public DateTime DateOAdding { get; set; }
    }
}
