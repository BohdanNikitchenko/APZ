using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public UserModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            //Patronymic = user.Patronymic;
            Passport = user.Passport;
            TaxIdentity = user.TaxIdentity;
            CityId = user.CityId;
            City = user.City;
            Email = user.Email;
            Role = user.Role;
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        
        
        public string Surname { get; set; }

        
        //public string Patronymic { get; set; }

        [Required(ErrorMessage = "Не указан номер паспорта")]
        [RegularExpression(@"(^[А-ГҐДЕЄЖЗИІЇЙК-Я]{2}\d{6}$)|(^\d{9}$)", ErrorMessage = "Некорректный номер паспорта")]
        public string Passport { get; set; }

        [Required(ErrorMessage = "Не указан номер ИНН")]
        [RegularExpression(@"(^\d{10}$", ErrorMessage = "Некорректный номер ИНН")]
        public string TaxIdentity { get; set; }
        public int CityId { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        public string Role { get; set; } = "user";
        public City City { get; set; }
        public int SumSizeFine { get; set; }
    }
}
