using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddTechnicModel
    {
        [Required(ErrorMessage = "AutoNumberRequired")]
        [RegularExpression(@"\w*", ErrorMessage = "AutoNumberError")]
        [Display(Name = "AutoNumber")]
        public string AutoNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "TechnicData")]
        public DateTime YearOfCarManufacture { get; set; }

        [Range(200, 10000, ErrorMessage = "EngineVolumeError")]
        [Display(Name = "EngineVolume")]
        public int EngineVolume { get; set; }
        [Display(Name = "TechnicType")]
        public int TechnicTypeId { get; set; }
        public List<SelectListItem> TechnicTypeList { get; set; }

    }
}
