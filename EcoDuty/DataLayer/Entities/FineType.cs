using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class FineType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int SizeFine { get; set; }
        public List<Fine> Fines { get; set; }
    }
}
