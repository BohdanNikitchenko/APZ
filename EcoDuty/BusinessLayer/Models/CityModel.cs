using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class CityModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CityRequired")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "CityError")]
        [Display(Name = "City")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CountryRequired")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "CountryError")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        public string Status { get; set; }
    }
}
