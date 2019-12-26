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
            if (dataManager.UsersRepository.FindUserByPassport(u.Passport) != null)
            {
                return null;
            }
            User user = new User();
            user.Password = HashStaticService.HashPassword(u.Password);
            City city = dataManager.CitiesRepository.GetItemByName(u.City);
            user.Name = EncryptingStaticService.Encrypt(u.Name, user.Password);
            user.Surname = EncryptingStaticService.Encrypt(u.Surname, user.Password);
            //user.Patronymic = EncryptingStaticService.Encrypt(u.Patronymic, user.Password);
            user.Passport = u.Passport;
            user.CityId = city.Id;
            user.TaxIdentity = EncryptingStaticService.Encrypt(u.TaxIdentity, user.Password);
            user.City = city;
            user.Email = EncryptingStaticService.Encrypt(u.Email, user.Password);
            dataManager.UsersRepository.Create(user);
            return user;
        }

        public IEnumerable<string> GetNumerableCitiesName()
        {
            return dataManager.CitiesRepository.GetList().Select(c => c.Name);
        }

        public UserModel FindUserModelByPassport(string name)
        {
            User user = dataManager.UsersRepository.FindUserByPassport(name);
            user = EncryptingStaticService.Decrypt(user, user.Password);
            UserModel model = new UserModel(user);

            //int sumTechnicFine = user.Technics.Sum(x => x.SizeFine);
            //int sumPlaceFine = user.Places.Sum(x => x.SizeFine);
            //int sumSensorFine = user.Sensors
            //    .Sum(x => dataManager.FinesRepository
            //    .GetSumFinesById(x.Id));
            //model.SumSizeFine = sumTechnicFine + sumPlaceFine + sumSensorFine;
            model.SumSizeFine = FineService.GetSumUserFines(user, dataManager);
            return model;
        }

        public User FindUserByPassport(string name)
        {
            User user = dataManager.UsersRepository.FindUserByPassport(name);
            if(user != null)
            {
                return EncryptingStaticService.Decrypt(user, user.Password);
            }
            else
            {
                return null;
            }
        }

        public User IsRegistrated(string passport, string password)
        {
            //var obj = dataManager.UsersRepository.FindUserByPassport(passport);
            User obj = FindUserByPassport(passport);
            if(obj != null)
            {
                if (HashStaticService.VerifyHashedPassword(obj.Password, password))
                {
                    return obj;
                }
            }
            return null;
        }

        public IEnumerable<Place> GetAllPlaces(string name)
        {
            User user = FindUserByPassport(name);
            if(user != null)
            {
                return dataManager.PlacesRepository.GetList().Where(x => x.UserId == user.Id);
            }
            return null;
        }

        public IEnumerable<Technic> GetAllTechnics(string name)
        {
            User user = FindUserByPassport(name);
            if(user != null)
            {
                return dataManager.TechnicsRepository.GetList().Where(x => x.UserId == user.Id);
            }
            return null;
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
                //place.User = user;
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

        public void RemovePlaceById(int id, string name)
        {
            Place place = GetPlaceById(id);
            if(place.User.Passport == name)
            {
                place.Address = null;
                dataManager.PlacesRepository.Update(place);
            }
            //dataManager.PlacesRepository.Delete(id);
        }

        public List<SelectListItem> GetAllTechnicTypesSelect()
        {
            return dataManager.TechnicTypesRepository.GetList()
                .Select(c => new SelectListItem() { Text = c.Type + " : " + c.Classification + " : " + c.Fuel,
                    Value = c.Id.ToString() }).ToList();
        }

        public IEnumerable<Sensor> GetAllSensors(string name)
        {
            User user = FindUserByPassport(name);
            if(user != null)
            {
                return dataManager.SensorsRepository.GetList().Where(x => x.UserId == user.Id);
            }
            return null;
        }

        public void AddTechnic(AddTechnicModel model, string name)
        {
            Technic technic = new Technic();
            User user = FindUserByPassport(name);
            TechnicType technicType = dataManager.TechnicTypesRepository.GetItem(Convert.ToInt32(model.TechnicTypeId));
            if (user != null && technicType != null && dataManager.TechnicsRepository.FindTechnicByUser_AutoNumber(model.AutoNumber) == null)
            {
                //technic.User = user;
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

        public bool UniqueNumber(string autoNumber)
        {
            if(dataManager.TechnicsRepository.FindTechnicByUser_AutoNumber(autoNumber) == null)
            {
                return true;
            }
            return false;
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

        public bool UniqueSensorNumber(string serialNumber)
        {
            if(dataManager.SensorsRepository.GetSensorBySerialNumber(serialNumber) == null)
            {
                return true;
            }
            return false;
        }

        public Technic GetTechnicById(int id)
        {
            return dataManager.TechnicsRepository.GetItem(id);
        }

        public void RemoveTechnicById(int id, string name)
        {
            Technic technic = GetTechnicById(id);
            if(technic.User.Passport == name)
            {
                technic.AutoNumber = null;
                dataManager.TechnicsRepository.Update(technic);
            }
            //dataManager.TechnicsRepository.Delete(id);
        }

        public List<SelectListItem> GetAllSensorTypesSelect()
        {
            return dataManager.SensorTypesRepository.GetList()
                .Select(c => new SelectListItem()
                {
                    Text = c.Type,
                    Value = c.Id.ToString()
                }).ToList();
        }

        public void AddSensor(AddSensorModel model, string name)
        {
            Sensor sensor = new Sensor();
            User user = FindUserByPassport(name);
            SensorType sensorType = dataManager.SensorTypesRepository.GetItem(Convert.ToInt32(model.SensorTypeId));
            if (user != null && sensorType != null && dataManager.SensorsRepository.FindSensorByUser_SerialNumber(user.Id, model.SerialNumber) == null)
            {
                //sensor.User = user;
                sensor.UserId = user.Id;
                sensor.SensorTypeId = sensorType.Id;
                sensor.SensorType = sensorType;
                sensor.SerialNumber = model.SerialNumber;
                dataManager.SensorsRepository.Create(sensor);
                //place = dataManager.PlacesRepository.FindPlaceByUser_Address(user.Id, model.Address);
            }
        }

        public void ChangeUserData(UserChangeModel u)
        {
            User user = dataManager.UsersRepository.GetItem(u.Id);
            
            City city = dataManager.CitiesRepository.GetItemByName(u.City);
            user.Name = EncryptingStaticService.Encrypt(u.Name, user.Password);
            user.Surname = EncryptingStaticService.Encrypt(u.Surname, user.Password);
            user.CityId = city.Id;
            user.City = city;
            user.Email = EncryptingStaticService.Encrypt(u.Email, user.Password);
            dataManager.UsersRepository.Update(user);
        }

        public UserChangeModel GetChangeUserModel(string name)
        {
            User user = FindUserByPassport(name);
            UserChangeModel model = new UserChangeModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                City = user.City.Name,
                Email = user.Email
            };
            return model;
        }

        public IEnumerable<Fine> GetAllFines(string name)
        {
            User user = FindUserByPassport(name);
            if(user != null)
            {
                return dataManager.FinesRepository.GetList().Where(x => x.Sensor.UserId == user.Id);
            }
            return null;
        }

        public void RemoveSensorById(int id, string name)
        {
            Sensor sensor = GetSensorById(id);
            if (sensor.User.Passport == name)
            {
                sensor.SerialNumber = null;
                dataManager.SensorsRepository.Update(sensor);
            }
        }

        public Sensor GetSensorById(int id)
        {
            return dataManager.SensorsRepository.GetItem(id);
        }
    }
}
