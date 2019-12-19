using BusinessLayer.Models;
using DAL;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class RatingService
    {
        private DataManager dataManager;

        public RatingService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<CityRatingModel> GetAllCities()
        {
            IEnumerable<City> cities = dataManager.CitiesRepository.GetList();
            List<CityRatingModel> cityRatingModels = new List<CityRatingModel>();
            foreach(var city in cities)
            {
                int sum = city.Users.Sum(x => FineService.GetSumUserFines(x.Id, dataManager));
                cityRatingModels.Add(new CityRatingModel
                {
                    Id = city.Id,
                    Country = city.Country,
                    Name = city.Name,
                    SumFines = sum
                });
            }
            return cityRatingModels.OrderBy(x => x.SumFines);
        }
    }
}
