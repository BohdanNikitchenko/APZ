using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "NameRequired")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "NameError")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SurnameRequired")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "SurnameError")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        
        //[RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "Отчество указано неверно")]
        //public string Patronymic { get; set; }

        [Required(ErrorMessage = "PassportRequired")]
        [RegularExpression(@"(^[А-ГҐДЕЄЖЗИІЇЙК-Я]{2}\d{6}$)|(^\d{9}$)", ErrorMessage = "PassportError")]
        [Display(Name = "Passport")]
        public string Passport { get; set; }


        [Required(ErrorMessage = "TaxIdentRequiered")]
        [RegularExpression(@"\d{10}", ErrorMessage = "TaxIdentError")]
        [Display(Name = "TaxIdentity")]
        public string TaxIdentity { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "PasswordError")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "ConfirmPasswordError")]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }


        [EmailAddress(ErrorMessage = "EmailError")]
        [Required(ErrorMessage = "EmailRequired")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "EmailError")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public IEnumerable<string> Cities { get; set; }


    }
}
