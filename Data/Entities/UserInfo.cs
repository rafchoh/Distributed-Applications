using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserInfo : BaseEntity
    {
        [StringLength(30)]
        public string FullName { get; set; }
        public byte Age { get; set; }

        [StringLength(13)]
        public string PhoneNum { get; set; }
        [StringLength(90)]
        public string Address { get; set; }

        public DateTime DateORegistration { get; set; }
        public long DebtCard { get; set; }
    }
}
