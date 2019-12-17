using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DAL.Interfaces
{
    public interface ITechnicsRepository : IRepository<Technic>
    {
        object FindTechnicByUser_AutoNumber(int id, string autoNumber);
    }
}
