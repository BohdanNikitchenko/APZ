using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class TechnicType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Classification { get; set; }
        public int SizeFine { get; set; }
        public List<Technic> Technics { get; set; }
    }
}
