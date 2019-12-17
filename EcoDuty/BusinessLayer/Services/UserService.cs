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

        public UserModel FindUserModelByPassport(string name)
        {
            User user = dataManager.UsersRepository.FindUserByPassport(name);
            UserModel model = new UserModel(user);
            int sumTechnicFine = user.Technics.Sum(x => x.SizeFine);
            int sumPlaceFine = user.Places.Sum(x => x.SizeFine);
            //int sumSensorFine = user.Sensors.Sum(x => x.Fines.Sum(c => c.SizeFine));
            int sumSensorFine = user.Sensors
                .Sum(x => dataManager.FinesRepository
                .GetSumFinesById(x.Id));
            model.SumSizeFine = sumTechnicFine + sumPlaceFine + sumSensorFine;
            return model;
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
            User user = FindUserByPassport(name);
            PlaceType placeType = dataManager.PlaceTypesRepository.GetItem(Convert.ToInt32(model.PlaceTypeId));
            if(user != null && placeType != null && dataManager.PlacesRepository.FindPlaceByUser_Address(user.Id, model.Address) == null)
            {
                place.User = user;
                place.UserId = user.Id;
                place.PlaceTypeId = placeType.Id;
                place.PlaceType = placeType;
                place.Address = model.Address;
                place.SizeFine = placeType.SizeFine;
                dataManager.PlacesRepository.Create(place);
                //place = dataManager.PlacesRepository.FindPlaceByUser_Address(user.Id, model.Address);
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

        public List<SelectListItem> GetAllTechnicTypesSelect()
        {
            return dataManager.TechnicTypesRepository.GetList()
                .Select(c => new SelectListItem() { Text = c.Type + " : " + c.Classification + " : " + c.Fuel,
                    Value = c.Id.ToString() }).ToList();
        }

        public void AddTechnic(AddTechnicModel model, string name)
        {
            Technic technic = new Technic();
            User user = FindUserByPassport(name);
            TechnicType technicType = dataManager.TechnicTypesRepository.GetItem(Convert.ToInt32(model.TechnicTypeId));
            if (user != null && technicType != null && dataManager.PlacesRepository.FindPlaceByUser_Address(user.Id, model.AutoNumber) == null)
            {
                technic.User = user;
                technic.UserId = user.Id;
                technic.TechnicTypeId = technicType.Id;
                technic.TechnicType = technicType;
                technic.AutoNumber = model.AutoNumber;
                technic.EngineVolume = model.EngineVolume;
                technic.YearOfCarManufacture = model.YearOfCarManufacture;
                technic.SizeFine = technicType.SizeFine + AutosCharactersFine(technic.YearOfCarManufacture, technic.EngineVolume);
                dataManager.TechnicsRepository.Create(technic);
                //place = dataManager.PlacesRepository.FindPlaceByUser_Address(user.Id, model.Address);
            }
        }

        private int AutosCharactersFine(DateTime yearOfCarManufacture, int engineVolume)
        {
            int fine = 0;
            int yearRange = DateTime.Today.Year - yearOfCarManufacture.Year;
            if (yearRange > 10)
            {
                fine += yearRange * 10;
            }
            if(engineVolume > 1999)
            {
                fine += engineVolume / 100;
            }
            return fine;
        }

        public Technic GetTechnicById(int id)
        {
            return dataManager.TechnicsRepository.GetItem(id);
        }

        public void RemoveTechnicById(int id)
        {
            dataManager.TechnicsRepository.Delete(id);
        }
    }
}
