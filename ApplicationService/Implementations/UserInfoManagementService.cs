using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Implementations;

namespace ApplicationService.Implementations
{
    public class UserInfoManagementService
    {
        private LibraryCopySystemDBContext context = new LibraryCopySystemDBContext();
        //
        //
        //
        public List<UserInfoDTO> Get()
        {
            List<UserInfoDTO> usersDto = new List<UserInfoDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserInfoRepository.Get())
                {
                    usersDto.Add(new UserInfoDTO
                    {
                        Id = item.Id,
                        FullName = item.FullName,
                        Age = item.Age,
                        PhoneNum = item.PhoneNum,
                        Address = item.Address,
                        DateORegistration = item.DateORegistration,
                        DebtCard = item.DebtCard
                    });
                }
            }

            return usersDto;
        }
        //
        //
        public bool Save(UserInfoDTO userInfoDto)
        {
            UserInfo UserInfo = new UserInfo
            {
                FullName = userInfoDto.FullName,
                Age = userInfoDto.Age,
                PhoneNum = userInfoDto.PhoneNum,
                Address = userInfoDto.Address,
                DateORegistration = userInfoDto.DateORegistration,
                DebtCard = userInfoDto.DebtCard
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserInfoRepository.Insert(UserInfo);
                    unitOfWork.Save();
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        //
        public bool Update(UserInfoDTO userInfoDTO)
        {
            UserInfo UserInfo = new UserInfo
            {
                Id = userInfoDTO.Id,
                FullName = userInfoDTO.FullName,
                Age = userInfoDTO.Age,
                PhoneNum = userInfoDTO.PhoneNum,
                Address = userInfoDTO.Address,
                DateORegistration = userInfoDTO.DateORegistration,
                DebtCard = userInfoDTO.DebtCard
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserInfoRepository.Update(UserInfo);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        //
        public UserInfoDTO GetUserById(int id)
        {
            UserInfoDTO userInfoDto = new UserInfoDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                UserInfo userInfo = unitOfWork.UserInfoRepository.GetByID(id);
                userInfoDto = new UserInfoDTO
                {
                    Id = userInfo.Id,
                    FullName = userInfo.FullName,
                    Age = userInfo.Age,
                    PhoneNum = userInfo.PhoneNum,
                    Address = userInfo.Address,
                    DateORegistration = userInfo.DateORegistration,
                    DebtCard = userInfo.DebtCard
                };
            }

            return userInfoDto;
        }
        //
        //
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    UserInfo userInfo = context.UsersInfo.Find(id);
                    unitOfWork.UserInfoRepository.Delete(userInfo);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        //
    }
}