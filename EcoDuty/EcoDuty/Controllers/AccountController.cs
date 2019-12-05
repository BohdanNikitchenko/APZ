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
            if (ModelState.IsValid)
            {
                bool t = servicesmanager.Users.RegistrateUser(model);
                if (t)
                {
                    await Authenticate(model.Passport); // аутентификация
                    return RedirectToAction("Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные паспортные данные");
            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
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
                    await Authenticate(model.Passport); // аутентификация

                    return RedirectToAction("Account", "Account");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
    }
}