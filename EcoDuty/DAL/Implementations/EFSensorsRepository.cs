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
    class EFSensorsRepository : IRepository<Sensor>
    {
        private EFDBContext context;
        public EFSensorsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Sensor> GetList()
        {
            return context.Set<Sensor>()
                .Include(x => x.User)
                .Include(x=>x.SensorType)
                .AsNoTracking().ToList();
        }

        public Sensor GetItem(int id)
        {
            return context.Set<Sensor>()
                .Include(x => x.User)
                .Include(x => x.SensorType)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(Sensor item)
        {
            context.Sensors.Add(item);
            context.SaveChanges();
        }

        public void Update(Sensor item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sensor = context.Find<Sensor>(id);
            if (sensor != null)
            {
                context.Sensors.Remove(sensor);
            }
            context.SaveChanges();
        }
    }
}
