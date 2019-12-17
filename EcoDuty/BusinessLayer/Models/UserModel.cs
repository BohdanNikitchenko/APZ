using DataLayer.Entities;
using System;
using System.Collections.Generic;
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
            Patronymic = user.Patronymic;
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
        public string Patronymic { get; set; }
        public string Passport { get; set; }
        public string TaxIdentity { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "user";
        public City City { get; set; }
        public int SumSizeFine { get; set; }
    }
}
