using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DAL.Interfaces
{
    public interface IFinesRepository : IRepository<Fine>
    {
        int GetSumFinesById(int id);
    }
}
