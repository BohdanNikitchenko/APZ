using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class UserChangeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "Имя указано неверно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "Фамилия указана неверно")]
        public string Surname { get; set; }
        public string City { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        public IEnumerable<string> Cities { get; set; }

    }
}
