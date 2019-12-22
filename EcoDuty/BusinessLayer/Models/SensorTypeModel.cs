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
        [Required(ErrorMessage = "Не указано название типа сенсора")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Размер названия типа сенсора от 1 до 30 символов")]
        public string Type { get; set; }
        public string ResType { get; set; }
        public string NormalString { get; set; }
        public bool? NormalBool { get; set; }
        public int? NormalInt { get; set; }
        public int SizeFine { get; set; }
        public IEnumerable<string> ResTypeList { get; set; } = new List<string> { "Int", "String", "Bool" };

    }
}
