using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Models
{
    public class PlaceTypeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано название типа помещения")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Размер названия типа помещения от 3 до 30 символов")]
        public string HousingType { get; set; }
        [Required(ErrorMessage = "Не указано название экологичесвого помещения")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Размер названия экологического типа помещения от 3 до 30 символов")]
        public string EcoType { get; set; }
        public int SizeFine { get; set; }
    }
}
