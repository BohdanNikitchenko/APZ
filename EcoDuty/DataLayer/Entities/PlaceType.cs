using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class PlaceType
    {
        public int Id { get; set; }
        public string HousingType { get; set; }
        public string EcoType { get; set; }
        public int SizeFine { get; set; } = 0;
        public List<Place> Places { get; set; }
    }
}
