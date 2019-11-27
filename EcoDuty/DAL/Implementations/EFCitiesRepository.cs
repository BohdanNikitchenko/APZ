using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DAL.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class EFCitiesRepository : ICitiesRepository
    {
        private EFDBContext context;
        public EFCitiesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<City> GetList()
        {
            return context.Set<City>()
                .Include(x => x.Users)
                .AsNoTracking().ToList();
        }

        public City GetItem(int id)
        {
            return context.Set<City>()
                .Include(x => x.Users)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(City item)
        {
            context.Cities.Add(item);
            context.SaveChanges();
        }

        public void Update(City item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            City city = context.Find<City>(id);
            if (city != null)
            {
                context.Cities.Remove(city);
            }
            context.SaveChanges();
        }
    }
}
