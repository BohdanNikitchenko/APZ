using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class TechnicTypeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name of the type of technics is not indicated")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The size of the name of the type of technics is from 3 to 30 characters")]
        [Display(Name = "Type of technics")]
        public string Type { get; set; }
        [Required(ErrorMessage = "The name of the class of technology is not indicated")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Vehicle class name size from 3 to 30 characters")]
        [Display(Name = "Class of technics")]
        public string Classification { get; set; }
        [Display(Name = "SizeFine")]
        public int SizeFine { get; set; } = 0;
    }
}
