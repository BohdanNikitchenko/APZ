using CryptoDataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICryptoRepository : IRepository<Crypto>
    {
        string GetPassByuserId(int userId);
    }
}
