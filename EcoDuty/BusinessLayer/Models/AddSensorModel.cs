using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddSensorModel
    {
        [Required(ErrorMessage = "SerialRequired")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "SerialError")]
        [Display(Name = "SerialNumber")]
        public string SerialNumber { get; set; }
        [Display(Name = "SensorType")]
        public int SensorTypeId { get; set; }
        public List<SelectListItem> SensorTypeList { get; set; }
    }
}
