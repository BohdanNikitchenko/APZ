using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class SensorAPIModel
    {
        public string SerialNumber { get; set; }
        public string CurrentString { get; set; }
        public int? CurrentInt { get; set; }
        public bool? CurrentBool { get; set; }
    }
}
