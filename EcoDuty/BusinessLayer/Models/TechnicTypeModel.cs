using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class TechnicTypeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название типа техники")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Размер названия типа техники от 3 до 30 символов")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Не указано название класса техники")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Размер названия класса техники от 3 до 30 символов")]
        public string Classification { get; set; }
        public int SizeFine { get; set; } = 0;
    }
}
