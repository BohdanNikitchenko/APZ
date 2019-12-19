using DAL;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    internal class FineService
    {
        private DataManager dataManager;

        public FineService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        internal void SensorFineInt(Sensor sensor)
        {
            if(sensor.CurrentInt != null)
            {
                if (!sensor.Flag  && sensor.CurrentInt > sensor.SensorType.NormalInt)
                {
                    Fine fine = new Fine
                    {
                        Sensor = sensor,
                        SensorId = sensor.Id,
                        DateTime = DateTime.Now,
                        Description = "Превышение нормы показателя датчика " + sensor.SensorType.Type,
                        SizeFine = sensor.SensorType.SizeFine
                    };
                    dataManager.FinesRepository.Create(fine);
                    sensor.Flag = true;
                    sensor.CounterFines = 0;
                }
                else if (sensor.Flag && sensor.CurrentInt > sensor.SensorType.NormalInt)
                {
                    sensor.CounterFines++;
                }
                else if (sensor.Flag && sensor.CurrentInt < sensor.SensorType.NormalInt)
                {
                    sensor.Flag = false;
                    sensor.CounterFines = 0;
                }
            }
            dataManager.SensorsRepository.Update(sensor);
        }

        internal void SensorFineBool(Sensor sensor)
        {
            if (sensor.CurrentBool != null)
            {
                if (!sensor.Flag && sensor.CurrentBool != sensor.SensorType.NormalBool)
                {
                    Fine fine = new Fine
                    {
                        Sensor = sensor,
                        SensorId = sensor.Id,
                        DateTime = DateTime.Now,
                        Description = "Превышение нормы показателя датчика " + sensor.SensorType.Type,
                        SizeFine = sensor.SensorType.SizeFine
                    };
                    dataManager.FinesRepository.Create(fine);
                    sensor.Flag = true;
                    sensor.CounterFines = 0;
                }
                else if (sensor.Flag && sensor.CurrentBool != sensor.SensorType.NormalBool)
                {
                    sensor.CounterFines++;
                }
                else if (sensor.Flag && sensor.CurrentBool == sensor.SensorType.NormalBool)
                {
                    sensor.Flag = false;
                    sensor.CounterFines = 0;
                }
            }
            dataManager.SensorsRepository.Update(sensor);
        }

        internal void SensorFineString(Sensor sensor)
        {
            throw new NotImplementedException();
        }

        internal static int GetSumUserFines(User user, DataManager dataManager)
        {
           int result = 0;
            result += user.Technics.Sum(x => x.SizeFine);
            result += user.Places.Sum(x => x.SizeFine);
            result += user.Sensors
                .Sum(x => dataManager.FinesRepository
                .GetSumFinesById(x.Id));
            //result = sumSensorFine + sumTechnicFine + sumPlaceFine;
            return result;
        }

        internal static int GetSumUserFines(int userId, DataManager dataManager)
        {
            User user = dataManager.UsersRepository.GetItem(userId);
            int result = 0;
            if(user != null)
            {
                result += user.Technics.Sum(x => x.SizeFine);
                result += user.Places.Sum(x => x.SizeFine);
                result += user.Sensors
                    .Sum(x => dataManager.FinesRepository
                    .GetSumFinesById(x.Id));
            }
            return result;
        }
    }
}
