using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class EFPlaceTypeRepository : IPlaceTypeRepository
    {
        private EFDBContext context;
        public EFPlaceTypeRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void Create(PlaceType item)
        {
            context.PlaceTypes.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var placeType = context.Find<PlaceType>(id);
            if (placeType != null)
            {
                context.PlaceTypes.Remove(placeType);
            }
            context.SaveChanges();
        }

        public PlaceType GetItem(int id)
        {
            return context.Set<PlaceType>()
                .Include(x => x.Places)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<PlaceType> GetList()
        {
            return context.Set<PlaceType>()
                .Include(x => x.Places)
                .AsNoTracking().ToList();
        }

        public object GetSelectList()
        {
            throw new NotImplementedException();
        }

        public void Update(PlaceType item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
