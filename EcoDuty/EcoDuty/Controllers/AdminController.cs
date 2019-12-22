using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Models;
using DAL;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoDuty.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private DataManager datamanager;
        private ServiceManager servicesmanager;
        public AdminController(DataManager dataManager)
        {
            datamanager = dataManager;
            servicesmanager = new ServiceManager(dataManager);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewAllPlaceType()
        {
            IEnumerable<PlaceType> placeTypes = servicesmanager.Admin.GetAllPlaceTypes();
            return View(placeTypes);
        }

        [HttpGet]
        public IActionResult PlaceTypePage(int id)
        {
            PlaceTypeModel model = servicesmanager.Admin.GetPlaceTypeModelById(id);

            return View(model);
        }


        [HttpPost]
        public IActionResult PlaceTypePage(PlaceTypeModel model)
        {

            if (ModelState.IsValid)
            {
                servicesmanager.Admin.CahngePlaceType(model);
            }

            return PlaceTypePage(model.Id);
        }

        public IActionResult PlaceTypeRemove(int id)
        {
            servicesmanager.Admin.RemovePageTypeById(id);
            return RedirectToAction("ViewAllPlaceType");
        }

        [HttpGet]
        public IActionResult AddPlaceTypePage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlaceTypePage(PlaceTypeModel model)
        {
            if (ModelState.IsValid)
            {
                servicesmanager.Admin.AddPlaceType(model);
            }
            return RedirectToAction("ViewAllPlaceType");
        }

        [HttpGet]
        public IActionResult ViewAllTechnicType()
        {
            IEnumerable<TechnicType> techicTypes = servicesmanager.Admin.GetAllTechnicTypes();
            return View(techicTypes);
        }


        [HttpGet]
        public IActionResult TechnicTypePage(int id)
        {
            TechnicTypeModel model = servicesmanager.Admin.GetTechnicTypeModelById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult TechnicTypePage(TechnicTypeModel model)
        {

            if (ModelState.IsValid)
            {
                servicesmanager.Admin.CahngeTechnicType(model);
            }

            return TechnicTypePage(model.Id);
        }

        [HttpGet]
        public IActionResult AddTechnicTypePage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTechnicTypePage(TechnicTypeModel model)
        {
            if (ModelState.IsValid)
            {
                servicesmanager.Admin.AddTechnicType(model);
            }
            return RedirectToAction("ViewAllTechnicType");
        }

        [HttpGet]
        public IActionResult TechnicTypeRemove(int id)
        {
            servicesmanager.Admin.RemoveTechnicTypeById(id);
            return RedirectToAction("ViewAllTechnicType");
        }

        [HttpGet]
        public IActionResult ViewAllSensorType()
        {
            IEnumerable<SensorType> sensorTypes = servicesmanager.Admin.GetAllSensorTypes();
            return View(sensorTypes);
        }

        [HttpGet]
        public IActionResult ViewAllUser()
        {
            IEnumerable<User> users = servicesmanager.Admin.GetAllUsers();
            return View(users);
        }


        [HttpGet]
        public IActionResult ViewAllCities()
        {
            IEnumerable<City> cities = servicesmanager.Admin.GetAllCities();
            return View(cities);
        }

        [HttpGet]
        public IActionResult AddSensorTypePage()
        {
            SensorTypeModel sensorTypeModel = new SensorTypeModel();
            return View(sensorTypeModel);
        }

        [HttpPost]
        public IActionResult AddSensorTypePage(SensorTypeModel model)
        {
            if (ModelState.IsValid)
            {
                servicesmanager.Admin.AddSensorType(model);
            }
            return RedirectToAction("ViewAllSensorType");
        }

        [HttpGet]
        public IActionResult SensorTypePage(int id)
        {
            SensorTypeModel model = servicesmanager.Admin.GetSensorTypeModelById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult SensorTypePage(SensorTypeModel model)
        {
            if (ModelState.IsValid)
            {
                servicesmanager.Admin.CahngeSensorType(model);
            }

            return SensorTypePage(model.Id);
        }

        public IActionResult SensorTypeRemove(int id)
        {
            servicesmanager.Admin.RemoveSensorTypeById(id);
            return RedirectToAction("ViewAllSensorType");
        }


        [HttpGet]
        public IActionResult AddCityPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCityPage(CityModel model)
        {
            if (ModelState.IsValid)
            {
                servicesmanager.Admin.AddCity(model);
            }
            return RedirectToAction("ViewAllCities");
        }

        [HttpGet]
        public IActionResult CityPage(int id)
        {
            CityModel model = servicesmanager.Admin.GetCityModelById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult CityPage(CityModel model)
        {
            if (ModelState.IsValid)
            {
                servicesmanager.Admin.CahngeCity(model);
            }

            return CityPage(model.Id);
        }

        public IActionResult CityRemove(int id)
        {
            servicesmanager.Admin.RemoveCityById(id);
            return RedirectToAction("ViewAllCitiesType");
        }


        [HttpGet]
        public IActionResult UserPage(int id)
        {
            UserModel model = servicesmanager.Admin.GetUserModelById(id);
            return View(model);
        }

        public IActionResult UserRemove(int id)
        {

            bool res = servicesmanager.Admin.RemoveUserById(id, User.Identity.Name);
            if (res)
            {
                return RedirectToAction("Logout", "Account");
            }
            return RedirectToAction("ViewAllUser");
        }

        public IActionResult ChangeUserRole(int id)
        {
            servicesmanager.Admin.ChangeUserRole(id);
            //return UserPage(id);
            return RedirectToAction("UserPage", new { id });
        }

        [HttpGet]
        public IActionResult ViewAllPlace(string name)
        {
            IEnumerable<Place> places = servicesmanager.Users.GetAllPlaces(name);
            return View(places);
        }

        [HttpGet]
        public IActionResult ViewAllTechnic(string name)
        {
            IEnumerable<Technic> technics = servicesmanager.Users.GetAllTechnics(name);
            return View(technics);
        }

        [HttpGet]
        public IActionResult ViewAllSensor(string name)
        {
            IEnumerable<Sensor> sensors = servicesmanager.Users.GetAllSensors(name);
            return View(sensors);
        }

        public IActionResult PlaceRemove(int id)
        {
            string nameUser = servicesmanager.Admin.RemovePlaceById(id);
            return RedirectToAction("ViewAllPlace", new { name = nameUser });
        }

        public IActionResult TechnicRemove(int id)
        {
            string nameUser = servicesmanager.Admin.RemoveTechnicById(id);
            return RedirectToAction("ViewAllTechnic", new { name = nameUser });
        }

        public IActionResult SensorRemove(int id)
        {
            string nameUser = servicesmanager.Admin.RemoveSensorById(id);
            return RedirectToAction("ViewAllSensor", new { name = nameUser });
        }
    }
}