using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Technic
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TechnicTypeId { get; set; }
        public User User { get; set; }
        public TechnicType TechnicType { get; set; }
    }
}
