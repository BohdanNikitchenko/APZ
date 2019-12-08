using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddPlaceModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PlaceTypeId { get; set; }
        public List<SelectListItem> CityList { get; set; }
    }
}
