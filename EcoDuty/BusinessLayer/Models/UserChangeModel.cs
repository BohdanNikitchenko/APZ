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
        [Required(ErrorMessage = "NameRequired")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "NameError")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SurnameRequired")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$", ErrorMessage = "SurnameError")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        public string City { get; set; }

        [EmailAddress(ErrorMessage = "EmailError")]
        [Required(ErrorMessage = "EmailRequired")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "EmailError")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public IEnumerable<string> Cities { get; set; }

    }
}
