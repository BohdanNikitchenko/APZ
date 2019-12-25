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
            double avg = cities.Average(x => x.Users.Sum(x => FineService.GetSumUserFines(x.Id, dataManager)));
            double threshold1 = avg * 0.6;
            double threshold2 = avg * 1.2;
            List<CityRatingModel> cityRatingModels = new List<CityRatingModel>();
            string shape = "";
            foreach(var city in cities)
            {
                int sum = city.Users.Sum(x => FineService.GetSumUserFines(x.Id, dataManager));
                if(sum < threshold1)
                {
                    shape = "table-success";
                }
                else if(sum < threshold2)
                {
                    shape = "table-warning";
                }
                else
                {
                    shape = "table-danger";
                }
                cityRatingModels.Add(new CityRatingModel
                {
                    Id = city.Id,
                    Country = city.Country,
                    Name = city.Name,
                    SumFines = sum,
                    Shape = shape
                });
            }
            return cityRatingModels.OrderBy(x => x.SumFines);
        }
    }
}
