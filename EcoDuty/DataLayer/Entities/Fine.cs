using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Fine
    {
        public int Id { get; set; }
        public int SizeFine { get; set; } = 0;
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
