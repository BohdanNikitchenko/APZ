using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Models;
using DAL;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace EcoDuty.Controllers
{
    public class AccountController : Controller
    {
        private DataManager datamanager;
        private ServiceManager servicesmanager;
        private readonly IStringLocalizer<AccountController> _localizer;

        public AccountController(DataManager dataManager, IStringLocalizer<AccountController> localizer)
        {
            datamanager = dataManager;
            servicesmanager = new ServiceManager(dataManager);
            _localizer = localizer;
        }
        [HttpGet]
        public IActionResult Index()
        {
            RegisterUserModel model = new RegisterUserModel();
            IEnumerable<string> cities = servicesmanager.Users.GetNumerableCitiesName();
            model.Cities = cities;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterUserModel model)
        {
            if (ModelState.IsValid && model.Password == model.ConfirmPassword)
            {
                User user = servicesmanager.Users.RegistrateUser(model);
                if (user != null)
                {
                    await Authenticate(user.Passport, user.Role); // аутентификация
                    return RedirectToAction("Account");
                }
                else
                    ModelState.AddModelError("Passport", _localizer["UserRegisterUnique"]);
            }
            else
            {
                ModelState.AddModelError("Password", _localizer["PasswordsRegisterError"]);
            }

            return Index();
            //return View(model);
        }
        private async Task Authenticate(string userName, string role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Account()
        {
            //User u = servicesmanager.Users.FindUserByPassport(User.Identity.Name);
            UserModel model = servicesmanager.Users.FindUserModelByPassport(User.Identity.Name);
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = servicesmanager.Users.IsRegistrated(model.Passport, model.Password);

                if (user != null)
                {
                    await Authenticate(user.Passport, user.Role); // аутентификация

                    return RedirectToAction("Account", "Account");
                }
                ModelState.AddModelError("General", _localizer["IncorrectLoginGeneral"]);
                //Некорректные логин и(или) пароль
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public IActionResult ViewAllPlace()
        {
            
            IEnumerable<Place> places = servicesmanager.Users.GetAllPlaces(User.Identity.Name);
            return View(places);
        }


        [HttpGet]
        public IActionResult ViewAllTechnic()
        {
            IEnumerable<Technic> technics = servicesmanager.Users.GetAllTechnics(User.Identity.Name);
            return View(technics);
        }

        [HttpGet]
        public IActionResult ViewAllSensor()
        {
            IEnumerable<Sensor> sensors = servicesmanager.Users.GetAllSensors(User.Identity.Name);
            return View(sensors);
        }

        [HttpGet]
        public IActionResult AddPlacePage()
        {
            AddPlaceModel model = new AddPlaceModel();
            model.CityList = servicesmanager.Users.GetAllPlaceTypesSelect();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddPlacePage(AddPlaceModel model)
        {
            if (ModelState.IsValid)
            {
                servicesmanager.Users.AddPlace(model, User.Identity.Name);
                return RedirectToAction("ViewAllPlace");
            }
            return AddPlacePage();
            //return ViewAllPlace();
        }

        //[HttpGet]
        //public IActionResult PlacePage(int id)
        //{
        //    Place model = servicesmanager.Users.GetPlaceById(id);
        //    return View(model);
        //}
        public ActionResult PlacePage(int id)
        {
            Place model = servicesmanager.Users.GetPlaceById(id);
            return PartialView(model);
            //return View(model);
        }


        public IActionResult PlaceRemove(int id)
        {
            servicesmanager.Users.RemovePlaceById(id, User.Identity.Name);
            return RedirectToAction("ViewAllPlace");
        }


        [HttpGet]
        public IActionResult AddTechnicPage()
        {
            AddTechnicModel model = new AddTechnicModel();
            model.TechnicTypeList = servicesmanager.Users.GetAllTechnicTypesSelect();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTechnicPage(AddTechnicModel model)
        {
            if (ModelState.IsValid)
            {
                if (!servicesmanager.Users.UniqueNumber(model.AutoNumber))
                {
                    ModelState.AddModelError("AutoNumber", "ошибка уникальности");
                    return AddTechnicPage();
                }
                servicesmanager.Users.AddTechnic(model, User.Identity.Name);
                return RedirectToAction("ViewAllTechnic");
            }
            return AddTechnicPage();
            //return ViewAllPlace();
        }

        [HttpGet]
        public IActionResult TechnicPage(int id)
        {
            Technic model = servicesmanager.Users.GetTechnicById(id);
            return View(model);
        }


        public IActionResult TechnicRemove(int id)
        {
            servicesmanager.Users.RemoveTechnicById(id, User.Identity.Name);
            return RedirectToAction("ViewAllTechnic");
        }

        [HttpGet]
        public IActionResult AddSensorPage()
        {
            AddSensorModel model = new AddSensorModel();
            model.SensorTypeList = servicesmanager.Users.GetAllSensorTypesSelect();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSensorPage(AddSensorModel model)
        {
            if (ModelState.IsValid)
            {
                if (!servicesmanager.Users.UniqueSensorNumber(model.SerialNumber))
                {
                    ModelState.AddModelError("SerialNumber", "ошибка уникальности");
                    return AddSensorPage();
                }
                servicesmanager.Users.AddSensor(model, User.Identity.Name);
                return RedirectToAction("ViewAllSensor");
            }
            return AddSensorPage();
            //return ViewAllPlace();
        }

        [HttpGet]
        public IActionResult SensorPage(int id)
        {
            Sensor model = servicesmanager.Users.GetSensorById(id);
            return View(model);
        }


        public IActionResult SensorRemove(int id)
        {
            servicesmanager.Users.RemoveSensorById(id, User.Identity.Name);
            return RedirectToAction("ViewAllSensor");
        }



        [HttpGet]
        public IActionResult GeneralizeTechnicFine(string name)
        {
            
            IEnumerable<Technic> technics = servicesmanager.Users.GetAllTechnics(name);
            //return View(technics);
            return View(technics);
        }

        [HttpGet]
        public IActionResult GeneralizePlaceFine(string name)
        {

            IEnumerable<Place> places = servicesmanager.Users.GetAllPlaces(name);
            //return View(technics);
            return View(places);
        }

        [HttpGet]
        public IActionResult GeneralizeSensorFine(string name)
        {
            IEnumerable<Fine> fines = servicesmanager.Users.GetAllFines(name);
            return View(fines);
        }


        [HttpGet]
        public IActionResult ChangeUserData()
        {
            UserChangeModel model = servicesmanager.Users.GetChangeUserModel(User.Identity.Name);
            IEnumerable<string> cities = servicesmanager.Users.GetNumerableCitiesName();
            model.Cities = cities;
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangeUserData(UserChangeModel model)
        {
            if (ModelState.IsValid)
            {
                servicesmanager.Users.ChangeUserData(model);
                return RedirectToAction("Account");
            }
            return ChangeUserData();
            //return ViewAllPlace();
        }

    }


}