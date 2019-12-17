using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddTechnicModel
    {
        public string AutoNumber { get; set; }
        public DateTime YearOfCarManufacture { get; set; }
        public int EngineVolume { get; set; }
        public int TechnicTypeId { get; set; }
        public List<SelectListItem> TechnicTypeList { get; set; }

    }
}
