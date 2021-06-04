using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Cart : BaseEntity
    {
        public int UserInfoId { get; set; }

        public long ISBN { get; set; }
        [StringLength(30)]
        public string Author { get; set; }
        [StringLength(55)]
        public string BookName { get; set; }
        public decimal Price { get; set; }

        public DateTime DateOAdding { get; set; }


        [ForeignKey("UserInfoId")]
        public UserInfo UserInfo { get; set; }
    }
}
