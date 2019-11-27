using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class SensorType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ResType { get; set; }
        public string NormalString { get; set; }
        public bool? NormalBool { get; set; }
        public int? NormalInt { get; set; }
        public int SizeFine { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
