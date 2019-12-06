using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlaceTypeId { get; set; }
        public User User { get; set; }
        public PlaceType PlaceType { get; set; }
    }
}
