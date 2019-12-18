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

        public void SensorPOST(SensorAPIModel model)
        {
            Sensor sensor = dataManager.SensorsRepository.GetSensorBySerialNumber(model.SerialNumber);
            if(sensor != null)
            {
                FineService fineService = new FineService(dataManager);
                switch (sensor.SensorType.ResType)
                {
                    case "Int":
                        sensor.CurrentInt = model.CurrentInt;
                        fineService.SensorFineInt(sensor);
                        break;
                    case "String":
                        sensor.CurrentString = model.CurrentString;
                        //fineService.SensorFineString(sensor);
                        break;
                    case "Bool":
                        sensor.CurrentBool = model.CurrentBool;
                        fineService.SensorFineBool(sensor);
                        break;
                }
            }
        }
    }
}
