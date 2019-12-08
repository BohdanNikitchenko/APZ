using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Fine
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SizeFine { get; set; } = 0;
        public int FineTypeId { get; set; }
        public int UserId { get; set; }
        public FineType FineType { get; set; }
        public User User { get; set; }
    }
}
