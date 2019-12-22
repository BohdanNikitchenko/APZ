using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddPlaceModel
    {
        [Required(ErrorMessage = "Не указан адресс")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Размер адресса от 3 до 40 символов")]
        public string Address { get; set; }
        public string PlaceTypeId { get; set; }
        public List<SelectListItem> CityList { get; set; }
    }
}
