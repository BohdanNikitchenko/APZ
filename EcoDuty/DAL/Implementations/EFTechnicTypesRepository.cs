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
    class EFTechnicTypesRepository : IRepository<TechnicType>
    {
        private EFDBContext context;
        public EFTechnicTypesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<TechnicType> GetList()
        {
            return context.Set<TechnicType>()
                .Include(x => x.Technics)
                .AsNoTracking().ToList();
        }

        public TechnicType GetItem(int id)
        {
            return context.Set<TechnicType>()
                .Include(x => x.Technics)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(TechnicType item)
        {
            context.TechnicTypes.Add(item);
            context.SaveChanges();
        }

        public void Update(TechnicType item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var technicType = context.Find<TechnicType>(id);
            if (technicType != null)
            {
                context.TechnicTypes.Remove(technicType);
            }
            context.SaveChanges();
        }
    }
}
