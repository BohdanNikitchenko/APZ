using BusinessLayer.Models;
using DAL;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class SensorService
    {
        private DataManager dataManager;

        public SensorService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public void Test(SensorAPIModel model)
        {
            Sensor sensor = dataManager.SensorsRepository.GetSensorBySerialNumber(model.SerialNumber);
            Fine fine = new Fine
            {
                Sensor = sensor,
                SensorId = sensor.Id,
                Description = "Превышение нормы",
                SizeFine = 400
            };
            dataManager.FinesRepository.Create(fine);
        }
    }
}
