using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class TechnicTypeModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Classification { get; set; }
        public int SizeFine { get; set; } = 0;
    }
}
