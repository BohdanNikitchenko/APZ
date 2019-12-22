using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "Имя указано неверно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "Фамилия указана неверно")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указано отчество пользователя")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "Отчество указано неверно")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Не указан номер паспорта")]
        [RegularExpression(@"(^[А-ГҐДЕЄЖЗИІЇЙК-Я]{2}\d{6}$)|(^\d{9}$)", ErrorMessage = "Некорректный номер паспорта")]
        public string Passport { get; set; }


        [Required(ErrorMessage = "Не указан номер ИНН")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Некорректный номер ИНН")]
        public string TaxIdentity { get; set; }
        public string City { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 30 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }


        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        public IEnumerable<string> Cities { get; set; }


    }
}
