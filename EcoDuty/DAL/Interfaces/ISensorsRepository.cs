using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DAL.Interfaces
{
    public interface ISensorsRepository : IRepository<Sensor>
    {
        object FindSensorByUser_SerialNumber(int id, string serialNumber);
        Sensor GetSensorBySerialNumber(string serialNumber);
    }
}
