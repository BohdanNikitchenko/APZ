using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class RegisterUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Passport { get; set; }
        public string ConfirmPassword { get; set; }
        public string TaxIdentity { get; set; }
        public string City { get; set; }
        public string Password { get; set; }

        public IEnumerable<string> Cities { get; set; }
    }
}
