using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserInfoVM> userInfoVM = new List<UserInfoVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetUserInfo())
                {
                    userInfoVM.Add(new UserInfoVM(item));
                }
            }

            return View(userInfoVM);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserInfoVM userInfoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UserInfoDTO userInfoDto = new UserInfoDTO
                        {
                            FullName = userInfoVM.FullName,
                            Age = userInfoVM.Age,
                            PhoneNum = userInfoVM.PhoneNum,
                            DateORegistration = userInfoVM.DateORegistration,
                            Address = userInfoVM.Address,
                            DebtCard = userInfoVM.DebtCard
                        };
                        service.PostUserInfo(userInfoDto);
                    }
                    return RedirectToAction("About", "Home");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: UserInfo/Edit
        public ActionResult Edit(int id)
        {
            UserInfoVM userInfoVM = new UserInfoVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var userInfoDTO = service.GetUserByID(id);
                userInfoVM = new UserInfoVM(userInfoDTO);
            }

            return View(userInfoVM);
        }

        // POST: UserInfo/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserInfoVM userInfoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UserInfoDTO userInfoDto = new UserInfoDTO
                        {
                            Id = userInfoVM.Id,
                            FullName = userInfoVM.FullName,
                            Age = userInfoVM.Age,
                            PhoneNum = userInfoVM.PhoneNum,
                            Address = userInfoVM.Address,
                            DateORegistration = userInfoVM.DateORegistration,
                            DebtCard = userInfoVM.DebtCard
                        };

                        service.PutUserInfo(userInfoDto);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteUserInfo(id);
            }
            return RedirectToAction("Index");
        }
    }
}
