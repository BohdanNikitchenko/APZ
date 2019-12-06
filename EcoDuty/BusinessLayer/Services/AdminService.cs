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
    }
}
