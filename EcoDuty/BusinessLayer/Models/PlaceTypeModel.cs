using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class PlaceTypeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "HousingTypeRequired")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "HousingTypeError")]
        [Display(Name = "HousingType")]
        public string HousingType { get; set; }
        [Required(ErrorMessage = "EcoTypeRequired")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "EcoTypeError")]
        [Display(Name = "EcoType")]
        public string EcoType { get; set; }
        [Display(Name = "SizeFine")]
        public int SizeFine { get; set; }
    }
}
