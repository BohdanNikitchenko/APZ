using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан номер паспорта")]
        public string Passport { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string General { get; set; }
    }
}
