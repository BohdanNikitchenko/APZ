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
    class EFSensorTypesRepository : IRepository<SensorType>
    {
        private EFDBContext context;
        public EFSensorTypesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<SensorType> GetList()
        {
            return context.Set<SensorType>()
                .Include(x => x.Sensors)
                .AsNoTracking().ToList();
        }

        public SensorType GetItem(int id)
        {
            return context.Set<SensorType>()
                .Include(x => x.Sensors)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(SensorType item)
        {
            context.SensorTypes.Add(item);
            context.SaveChanges();
        }

        public void Update(SensorType item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sensorType = context.Find<SensorType>(id);
            if (sensorType != null)
            {
                context.SensorTypes.Remove(sensorType);
            }
            context.SaveChanges();
        }
    }
}
