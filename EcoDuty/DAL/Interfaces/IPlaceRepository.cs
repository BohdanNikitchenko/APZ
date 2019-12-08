using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DAL.Interfaces
{
    public interface IPlaceRepository : IRepository<Place>
    {
        Place FindPlaceByUser_Address(int id, string address);
    }
}
