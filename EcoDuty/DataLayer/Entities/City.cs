using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
        public List<User> Users { get; set; }
    }
}
