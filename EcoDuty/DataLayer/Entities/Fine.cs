using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Fine
    {
        public int Id { get; set; }
        public int FineTypeId { get; set; }
        public int UserId { get; set; }
        public FineType FineType { get; set; }
        public User User { get; set; }
    }
}
