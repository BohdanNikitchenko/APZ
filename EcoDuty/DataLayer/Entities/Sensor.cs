using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Sensor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SensorTypeId { get; set; }
        public User User { get; set; }
        public SensorType SensorType { get; set; }
        public string CurrentString { get; set; }
        public int? CurrentInt { get; set; }
        public bool? CurrentBool { get; set; }
        public int CounterFines { get; set; } = 0;
        public bool Flag { get; set; } = false;
        public List<Fine> Fines { get; set; }
    }
}
