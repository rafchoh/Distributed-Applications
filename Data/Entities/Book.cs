using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Book : BaseEntity
    {
        public long ISBN { get; set; }
        [StringLength(30)]
        public string Author { get; set; }
        [StringLength(55)]
        public string BookName { get; set; }
        [StringLength(15)]
        public string Genre { get; set; }
        public DateTime? DateORelease { get; set; }

        public decimal Price { get; set; }
    }
}
