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

namespace EcoDuty.Controllers
{
    public class AccountController : Controller
    {
        private DataManager datamanager;
        private ServiceManager servicesmanager;

        public AccountController(DataManager dataManager)
        {
            datamanager = dataManager;
            servicesmanager = new ServiceManager(dataManager);
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
                    ModelState.AddModelError("", "Некорректные паспортные данные");
            }
            else
            {
                ModelState.AddModelError("Password", "Пароли не совпадают");
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
            User u = servicesmanager.Users.FindUserByPassport(User.Identity.Name);
            return View(u);
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
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
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
            IEnumerable<Place> places = servicesmanager.Users.GetAllPlaces();
            return View(places);
        }


        [HttpGet]
        public IActionResult ViewAllTechnic()
        {
            IEnumerable<Technic> technics = servicesmanager.Users.GetAllTechnics();
            return View(technics);
        }
    }


}