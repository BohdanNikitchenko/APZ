using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoDataLayer.Entities
{
    public class Crypto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Pass { get; set; }
    }
}
