using BusinessLayer.Models;
using DAL;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class AdminService
    {
        private DataManager dataManager;

        public AdminService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<PlaceType> GetAllPlaceTypes()
        {
            return dataManager.PlaceTypesRepository.GetList();
        }

        public PlaceType GetPlaceById(in int id)
        {
            return dataManager.PlaceTypesRepository.GetItem(id);
        }

        public void RemovePageTypeById(int id)
        {
            dataManager.PlaceTypesRepository.Delete(id);
        }

        public void AddPlaceType(PlaceTypeModel model)
        {
            PlaceType placeType = new PlaceType();
            placeType.EcoType = model.EcoType;
            placeType.HousingType = model.HousingType;
            placeType.SizeFine = model.SizeFine;
            dataManager.PlaceTypesRepository.Create(placeType);
        }

        public PlaceTypeModel GetPlaceTypeModelById(int id)
        {
            PlaceType placeType = dataManager.PlaceTypesRepository.GetItem(id);
            PlaceTypeModel model = new PlaceTypeModel
            {
                EcoType = placeType.EcoType,
                HousingType = placeType.HousingType,
                Id = placeType.Id,
                SizeFine = placeType.SizeFine
            };

            return model;
        }

        public void CahngePlaceType(PlaceTypeModel model)
        {
            PlaceType placeType = new PlaceType
            {
                EcoType = model.EcoType,
                HousingType = model.HousingType,
                Id = model.Id,
                SizeFine = model.SizeFine
            };
            dataManager.PlaceTypesRepository.Update(placeType);
        }

        public IEnumerable<TechnicType> GetAllTechnicTypes()
        {
            return dataManager.TechnicTypesRepository.GetList();
        }

        public TechnicTypeModel GetTechnicTypeModelById(int id)
        {
            TechnicType placeType = dataManager.TechnicTypesRepository.GetItem(id);
            TechnicTypeModel model = new TechnicTypeModel
            {
                Type = placeType.Type,
                Classification = placeType.Classification,
                Id = placeType.Id,
                SizeFine = placeType.SizeFine
            };

            return model;
        }

        public void CahngeTechnicType(TechnicTypeModel model)
        {
            TechnicType technicType = new TechnicType
            {
                Type = model.Type,
                Classification = model.Classification,
                Id = model.Id,
                SizeFine = model.SizeFine
            };
            dataManager.TechnicTypesRepository.Update(technicType);
        }

        public void AddTechnicType(TechnicTypeModel model)
        {
            TechnicType technicType = new TechnicType();
            technicType.Type = model.Type;
            technicType.Classification = model.Classification;
            technicType.SizeFine = model.SizeFine;
            dataManager.TechnicTypesRepository.Create(technicType);
        }

        public void RemoveTechnicTypeById(in int id)
        {
            dataManager.TechnicTypesRepository.Delete(id);
        }

        public IEnumerable<SensorType> GetAllSensorTypes()
        {
            return dataManager.SensorTypesRepository.GetList();
        }

        public void AddSensorType(SensorTypeModel model)
        {
            SensorType sensorType = new SensorType();
            sensorType.Type = model.Type;
            sensorType.ResType = model.ResType;
            sensorType.NormalInt = model.NormalInt;
            sensorType.NormalBool = model.NormalBool;
            sensorType.NormalString = model.NormalString;
            sensorType.SizeFine = model.SizeFine;
            dataManager.SensorTypesRepository.Create(sensorType);
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> users = dataManager.UsersRepository.GetList();
            List<User> result = new List<User>();
            foreach(var user in users)
            {
                result.Add(EncryptingStaticService.Decrypt(user, user.Password));
            }
            return result;
        }

        public IEnumerable<City> GetAllCities()
        {
            return dataManager.CitiesRepository.GetList();
        }

        public SensorTypeModel GetSensorTypeModelById(int id)
        {
            SensorType sensorType = dataManager.SensorTypesRepository.GetItem(id);
            SensorTypeModel model = new SensorTypeModel
            {
                Type = sensorType.Type,
                ResType = sensorType.ResType,
                Id = sensorType.Id,
                NormalInt = sensorType.NormalInt,
                NormalBool = sensorType.NormalBool,
                NormalString = sensorType.NormalString,
                SizeFine = sensorType.SizeFine
            };

            return model;
        }

        public void CahngeSensorType(SensorTypeModel model)
        {
            SensorType sensorType = new SensorType
            {
                Type = model.Type,
                ResType = model.ResType,
                Id = model.Id,
                NormalInt = model.NormalInt,
                NormalBool = model.NormalBool,
                NormalString = model.NormalString,
                SizeFine = model.SizeFine
            };
            dataManager.SensorTypesRepository.Update(sensorType);
        }

        public void AddCity(CityModel model)
        {
            City city = new City();
            city.Country = model.Country;
            city.Name = model.Name;
            city.Status = model.Status;
            dataManager.CitiesRepository.Create(city);
        }

        public CityModel GetCityModelById(int id)
        {
            City city = dataManager.CitiesRepository.GetItem(id);
            CityModel model = new CityModel
            {
                Country = city.Country,
                Name = city.Name,
                Status = city.Status
            };

            return model;
        }

        public void RemoveCityById(int id)
        {
            dataManager.CitiesRepository.Delete(id);
        }

        public void CahngeCity(CityModel model)
        {
            City city = new City
            {
                Id = model.Id,
                Country = model.Country,
                Name = model.Name,
                Status = model.Status
            };
            dataManager.CitiesRepository.Update(city);
        }

        public void ChangeUserRole(int id)
        {
            User user = dataManager.UsersRepository.GetItem(id);
            //user = EncryptingStaticService.Decrypt(user, user.Password);
            if(user.Role == "user")
            {
                user.Role = "admin";
            }
            else
            {
                user.Role = "user";
            }
            dataManager.UsersRepository.Update(user);
        }

        public UserModel GetUserModelById(int id)
        {
            User user = dataManager.UsersRepository.GetItem(id);
            user = EncryptingStaticService.Decrypt(user, user.Password);
            UserModel model = new UserModel(user);
            int sumTechnicFine = user.Technics.Sum(x => x.SizeFine);
            int sumPlaceFine = user.Places.Sum(x => x.SizeFine);
            int sumSensorFine = user.Sensors
                .Sum(x => dataManager.FinesRepository
                .GetSumFinesById(x.Id));
            model.SumSizeFine = sumTechnicFine + sumPlaceFine + sumSensorFine;
            return model;
        }

        public void RemoveSensorTypeById(int id)
        {
            dataManager.SensorTypesRepository.Delete(id);
        }

        public string RemovePlaceById(int id)
        {
            string name = dataManager.PlacesRepository.GetItem(id).User.Passport;
            dataManager.PlacesRepository.Delete(id);
            return name;
        }

        public string RemoveTechnicById(int id)
        {
            string name = dataManager.TechnicsRepository.GetItem(id).User.Passport;
            dataManager.TechnicsRepository.Delete(id);
            return name;
        }

        public string RemoveSensorById(int id)
        {
            string name = dataManager.SensorsRepository.GetItem(id).User.Passport;
            dataManager.SensorsRepository.Delete(id);
            return name;
        }
    }
}
