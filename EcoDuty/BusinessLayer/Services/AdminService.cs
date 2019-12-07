using BusinessLayer.Models;
using DAL;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
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

        public void RemoveSensorTypeById(int id)
        {
            dataManager.SensorTypesRepository.Delete(id);
        }
    }
}
