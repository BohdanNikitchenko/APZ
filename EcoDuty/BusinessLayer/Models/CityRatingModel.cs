using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class CityRatingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int SumFines { get; set; }
        public string Shape { get; set; }
    }
}
