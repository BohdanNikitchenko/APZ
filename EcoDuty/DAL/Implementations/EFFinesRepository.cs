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
    class EFFinesRepository : IRepository<Fine>
    {
        private EFDBContext context;
        public EFFinesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Fine> GetList()
        {
            return context.Set<Fine>()
                .Include(x => x.FineType)
                .Include(x=>x.User)
                .AsNoTracking().ToList();
        }

        public Fine GetItem(int id)
        {
            return context.Set<Fine>()
                .Include(x => x.FineType)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(Fine item)
        {
            context.Fines.Add(item);
            context.SaveChanges();
        }

        public void Update(Fine item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var fine = context.Find<Fine>(id);
            if (fine != null)
            {
                context.Fines.Remove(fine);
            }
            context.SaveChanges();
        }
    }
}
