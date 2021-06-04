using ApplicationService.DTOs;
//using MVC.SOAPService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class UserInfoVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public byte Age { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }
        [Required]
        public string Address { get; set; }

        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        public DateTime DateORegistration { get; set; }
        [Display(Name = "Debt Cart Number")]
        public long DebtCard { get; set; }

        public UserInfoVM() { }

        public UserInfoVM(UserInfoDTO userInfoDTO)
        {
            Id = userInfoDTO.Id;
            FullName = userInfoDTO.FullName;
            Age = userInfoDTO.Age;
            PhoneNum = userInfoDTO.PhoneNum;
            Address = userInfoDTO.Address;
            DateORegistration = userInfoDTO.DateORegistration;
            DebtCard = userInfoDTO.DebtCard;
        }
    }
}