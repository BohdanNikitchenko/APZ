using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcoDuty.Models;
using DAL;
using DataLayer.Entities;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace EcoDuty.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataManager datamanager;
        private readonly ServiceManager servicesmanager;

        public HomeController(DataManager dataManager)
        {
            datamanager = dataManager;
            servicesmanager = new ServiceManager(dataManager);
        }

        public IActionResult Index()
        {
            IEnumerable<CityRatingModel> places = servicesmanager.Rating.GetAllCities();
            return View(places);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
