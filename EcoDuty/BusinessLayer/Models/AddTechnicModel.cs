using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddTechnicModel
    {
        [Required(ErrorMessage = "Не указан номер транспорта")]
        [RegularExpression(@"\w*", ErrorMessage = "Некорректный номер транспорта")]
        public string AutoNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime YearOfCarManufacture { get; set; }

        [Range(200, 10000, ErrorMessage = "Обьем двигателя от 200 до 10000")]
        public int EngineVolume { get; set; }
        public int TechnicTypeId { get; set; }
        public List<SelectListItem> TechnicTypeList { get; set; }

    }
}
