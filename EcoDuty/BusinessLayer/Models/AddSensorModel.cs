using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddSensorModel
    {
        public string SerialNumber { get; set; }
        public int SensorTypeId { get; set; }
        public List<SelectListItem> SensorTypeList { get; set; }
    }
}
