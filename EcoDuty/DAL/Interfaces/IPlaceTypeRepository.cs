using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DAL.Interfaces
{
    public interface IPlaceTypeRepository : IRepository<PlaceType>
    {
        object GetSelectList();
    }
}
