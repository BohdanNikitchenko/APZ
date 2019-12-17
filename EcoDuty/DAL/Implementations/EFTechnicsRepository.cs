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
    public class EFTechnicsRepository : ITechnicsRepository
    {
        private EFDBContext context;
        public EFTechnicsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Technic> GetList()
        {
            return context.Set<Technic>()
                .Include(x => x.User)
                .Include(x => x.TechnicType)
                .AsNoTracking().ToList();
        }

        public Technic GetItem(int id)
        {
            return context.Set<Technic>()
                .Include(x => x.User)
                .Include(x => x.TechnicType)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(Technic item)
        {
            context.Technics.Add(item);
            context.SaveChanges();
        }

        public void Update(Technic item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var technic = context.Find<Technic>(id);
            if (technic != null)
            {
                context.Technics.Remove(technic);
            }
            context.SaveChanges();
        }

        public object FindTechnicByUser_AutoNumber(int id, string autoNumber)
        {
            return context.Set<Technic>()
            .FirstOrDefault(x => x.UserId == id && x.AutoNumber == autoNumber);
        }
    }
}
