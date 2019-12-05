using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DAL.Interfaces
{
    public interface ICitiesRepository : IRepository<City>
    {
        City GetItemByName(string city);
    }
}
