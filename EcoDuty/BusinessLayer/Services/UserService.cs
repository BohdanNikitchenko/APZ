using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DAL;
using DataLayer.Entities;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private DataManager dataManager;

        public UserService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public bool RegistrateUser(RegisterUserModel u)
        {
            User user = new User();
            City city = dataManager.CitiesRepository.GetItemByName(u.City);
            user.Name = u.Name;
            user.Surname = u.Surname;
            user.Password = HashStaticService.HashPassword(u.Password);
            user.Patronymic = u.Patronymic;
            user.Passport = u.Passport;
            user.Surname = u.Surname;
            user.CityId = city.Id;
            user.TaxIdentity = u.TaxIdentity;
            user.City = city;
            if (dataManager.UsersRepository.FindUserByPassport(user.Passport) == null)
            {
                dataManager.UsersRepository.Create(user);
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<string> GetNumerableCitiesName()
        {
            return dataManager.CitiesRepository.GetList().Select(c => c.Name);
        }

        public User FindUserByPassport(string name)
        {
            return dataManager.UsersRepository.FindUserByPassport(name);
        }

        public User IsRegistrated(string passport, string password)
        {
            var obj = dataManager.UsersRepository.FindUserByPassport(passport);
            if (HashStaticService.VerifyHashedPassword(obj.Password, password))
            {
                return obj;
            }

            return null;
        }
    }
}
