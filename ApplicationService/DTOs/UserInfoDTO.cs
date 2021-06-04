using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class UserInfoDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public byte Age { get; set; }

        public string PhoneNum { get; set; }
        public string Address { get; set; }

        public DateTime DateORegistration { get; set; }
        public long DebtCard { get; set; }
    }
}
