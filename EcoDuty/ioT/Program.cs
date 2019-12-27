using BusinessLayer;
using DAL;
using DAL.Implementations;
using DAL.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace ioT
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDBContextFactory eventoDBContextFactory = new EFDBContextFactory();
            EFDBContext db = eventoDBContextFactory.CreateDbContext(args);
            ISensorsRepository sensors = new EFSensorsRepository(db);
            IFinesRepository fines = new EFFinesRepository(db);
            DataManager dm = new DataManager(sensors, fines);
            ServiceManager serviceManager = new ServiceManager(dm);
            string serialNumber;
            int res;
            while (true)
            {
                Console.WriteLine("Enter serial number:");
                serialNumber = Console.ReadLine();
                Console.WriteLine("Enter current value:");
                res = Convert.ToInt32(Console.ReadLine());
                serviceManager.Sensor.SensorInt(serialNumber, res);
                Console.WriteLine("Request was send");
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
