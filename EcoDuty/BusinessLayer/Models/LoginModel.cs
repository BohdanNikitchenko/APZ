using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "PassportRequired")]
        [Display(Name = "Passport")]
        public string Passport { get; set; }

        [Required(ErrorMessage = "PasswordError")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string General { get; set; }
    }
}
