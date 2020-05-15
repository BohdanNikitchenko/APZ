using DAL;
using DAL.Implementations;
using DAL.Interfaces;
using DataLayer;
using DataLayer.Entities;
using EcoDuty.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EcoDuty.Tests
{
    public class HomeControllerTests
    {
        

        [Fact]
        public void IndexViewResultNotNull()
        {
            HomeController controller = new HomeController(Initialize());
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

       

        private static DataManager Initialize()
        {
            string[] args = new string[5];
            EFDBContextFactory eventoDBContextFactory = new EFDBContextFactory();
            EFDBContext db = eventoDBContextFactory.CreateDbContext(args);
            ISensorsRepository sensors = new EFSensorsRepository(db);
            IFinesRepository fines = new EFFinesRepository(db);
            ICitiesRepository citiesRepository = new EFCitiesRepository(db);
            ISensorTypesRepository sensorTypesRepository = new EFSensorTypesRepository(db);
            ITechnicsRepository technicsRepository = new EFTechnicsRepository(db);
            ITechnicTypesRepository technicTypesRepository = new EFTechnicTypesRepository(db);
            IUsersRepository usersRepository = new EFUsersRepository(db);
            IPlaceRepository placesRepository = new EFPlacesRepository(db);
            IPlaceTypeRepository placeTypesRepository = new EFPlaceTypeRepository(db);
            return new DataManager(citiesRepository, fines,
             sensors,
             sensorTypesRepository, technicsRepository,
             technicTypesRepository, usersRepository,
             placesRepository, placeTypesRepository);
        }


        private List<City> GetTestUsers()
        {
            var cities = new List<City>
            {
                new City { Id=1, Name="Kharkiv", Country="Ukraine", Status="billioner"},
                new City { Id=2, Name="Kiev", Country="Ukraine", Status="billioner"},
                 new City { Id=3, Name="Lviv", Country="Ukraine", Status="billioner"},
            };
            return cities;
        }
    }
}
