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
    public class EFFineTypesRepository : IFineTypesRepository
    {
        private EFDBContext context;
        public EFFineTypesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<FineType> GetList()
        {
            return context.Set<FineType>()
                .Include(x => x.Fines)
                .AsNoTracking().ToList();
        }

        public FineType GetItem(int id)
        {
            return context.Set<FineType>()
                .Include(x => x.Fines)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(FineType item)
        {
            context.FineTypes.Add(item);
            context.SaveChanges();
        }

        public void Update(FineType item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var fineType = context.Find<FineType>(id);
            if (fineType != null)
            {
                context.FineTypes.Remove(fineType);
            }
            context.SaveChanges();
        }
    }
}
