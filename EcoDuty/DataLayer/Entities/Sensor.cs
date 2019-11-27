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

    }
}
