using BusinessLayer.Models;
using DAL;
using DAL.Implementations;
using DAL.Interfaces;
using DataLayer;
using EcoDuty.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EcoDuty.Tests
{
    public class AccountControllerTests
    {

        //[Fact]
        //public void LoginScreeningUnValidData()
        //{
        //    LoginModel model = new LoginModel
        //    {
        //        Passport = "000061015",
        //        Password = "bohdan1999"
        //    };
        //    // Arrange
        //    AccountController controller = new AccountController(Initialize());
        //    // Act
        //    ViewResult result = controller.Login(model) as ViewResult;
        //    // Assert
        //    Assert.Equal(model, result?.Model);
        //}


        //[Fact]
        //public void GetSensorModel()
        //{
        //    // Arrange
        //    AccountController controller = new AccountController(Initialize());
        //    // Act
        //    ViewResult result = controller.SensorPage(2) as ViewResult;
        //    // Assert
        //    Assert.Equal("SensorPage", result?.ViewName);
        //}



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
    }
   
}
