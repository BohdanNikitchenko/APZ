using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class SensorTypeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "SeonsorTypeRequired")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "SensorTypeError")]
        [Display(Name = "SensorType")]
        public string Type { get; set; }
        [Display(Name = "SensorTypeRes")]
        public string ResType { get; set; }
        [Display(Name = "Normal string value")]
        public string NormalString { get; set; }
        [Display(Name = "Normal bool value")]
        public bool? NormalBool { get; set; }
        [Display(Name = "Normal int value")]
        public int? NormalInt { get; set; }
        [Display(Name = "SizeFine")]
        public int SizeFine { get; set; }
        public IEnumerable<string> ResTypeList { get; set; } = new List<string> { "Int", "String", "Bool" };

    }
}
