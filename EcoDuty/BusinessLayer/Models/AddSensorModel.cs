using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddSensorModel
    {
        [Required(ErrorMessage = "Не указан серийный номер")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Размер серийного номера 10 символов")]
        public string SerialNumber { get; set; }
        public int SensorTypeId { get; set; }
        public List<SelectListItem> SensorTypeList { get; set; }
    }
}
