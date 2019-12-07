using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class SensorTypeModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ResType { get; set; }
        public string NormalString { get; set; }
        public bool? NormalBool { get; set; }
        public int? NormalInt { get; set; }
        public int SizeFine { get; set; }
    }
}
