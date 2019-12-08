using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Fine
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SizeFine { get; set; } = 0;
        public int UserId { get; set; }
        public int? TechnicId { get; set; }
        public int? PlaceId { get; set; }
        public int? SensorId { get; set; }
        public User User { get; set; }
        public Technic Technic { get; set; }
        public Place Place { get; set; }
        public Sensor Sensor { get; set; }
    }
}
