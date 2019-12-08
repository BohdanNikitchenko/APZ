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
    public class EFPlacesRepository : IPlaceRepository
    {
        private EFDBContext context;
        public EFPlacesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Place> GetList()
        {
            return context.Set<Place>()
                .Include(x => x.PlaceType)
                .Include(x => x.User)
                .AsNoTracking().ToList();
        }

        public Place GetItem(int id)
        {
            return context.Set<Place>()
                .Include(x => x.PlaceType)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(Place item)
        {
            context.Places.Add(item);
            context.SaveChanges();
        }

        public void Update(Place item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var place = context.Find<Place>(id);
            if (place != null)
            {
                context.Places.Remove(place);
            }
            context.SaveChanges();
        }

        public Place FindPlaceByUser_Address(int id, string address)
        {
            return context.Set<Place>()
            .Include(x => x.PlaceType)
            .Include(x => x.User)
            .FirstOrDefault(x => x.UserId == id && x.Address == address);
        }
    }
}
