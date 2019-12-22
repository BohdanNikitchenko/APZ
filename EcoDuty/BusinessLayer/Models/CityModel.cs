using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class CityModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано название города")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "Название города неверно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано название страны")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "Название города страны")]
        public string Country { get; set; }
        public string Status { get; set; }
    }
}
