using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DAL;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private DataManager dataManager;

        public UserService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public User RegistrateUser(RegisterUserModel u)
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
            user.Email = u.Email;
            if (dataManager.UsersRepository.FindUserByPassport(user.Passport) == null)
            {
                dataManager.UsersRepository.Create(user);
                return user;
            }

            return null;

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

        public IEnumerable<Place> GetAllPlaces()
        {
            return dataManager.PlacesRepository.GetList();
        }

        public IEnumerable<Technic> GetAllTechnics()
        {
            return dataManager.TechnicsRepository.GetList();
        }

       

        public List<SelectListItem> GetAllPlaceTypesSelect()
        {
            return dataManager.PlaceTypesRepository.GetList()
                .Select(c => new SelectListItem() { Text = c.HousingType + " : " + c.EcoType, Value = c.Id.ToString() })
                .ToList();
        }

        public void AddPlace(AddPlaceModel model, string name)
        {
            Place place = new Place();
            Fine fine = new Fine();
            User user = FindUserByPassport(name);
            PlaceType placeType = dataManager.PlaceTypesRepository.GetItem(Convert.ToInt32(model.PlaceTypeId));
            if(user != null && placeType != null && dataManager.PlacesRepository.FindPlaceByUser_Address(user.Id, model.Address) == null)
            {
                place.User = user;
                place.UserId = user.Id;
                place.PlaceTypeId = placeType.Id;
                place.PlaceType = placeType;
                place.Address = model.Address;
                dataManager.PlacesRepository.Create(place);
                place = dataManager.PlacesRepository.FindPlaceByUser_Address(user.Id, model.Address);
                fine.Place = place;
                fine.PlaceId = place.Id;
                fine.User = place.User;
                fine.UserId = place.UserId;
                fine.Description = "Экологические нормы дома";
                fine.SizeFine = place.PlaceType.SizeFine;
                dataManager.FinesRepository.Create(fine);
            }
        }

        public Place GetPlaceById(int id)
        {
            return dataManager.PlacesRepository.GetItem(id);
        }

        public void RemovePlaceById(int id)
        {
            dataManager.PlacesRepository.Delete(id);
        }
    }
}
