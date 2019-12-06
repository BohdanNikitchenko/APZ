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
    }
}