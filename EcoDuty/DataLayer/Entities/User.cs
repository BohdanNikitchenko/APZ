using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Passport { get; set; }
        public string TaxIdentity { get; set; }
        public int CityId { get; set; }
        public string Password { get; set; }
        public List<Fine> Fines { get; set; }
        public List<Technic> Technics { get; set; }
        public City City { get; set; }
        public List<Sensor> Sensors { get; set; }
        public List<Place> Places { get; set; }
    }
}
