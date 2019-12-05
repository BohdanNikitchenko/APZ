﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;

namespace DAL
{
    public class DataManager
    {
        private ICitiesRepository citiesRepository;
        private IFinesRepository finesRepository;
        private IFineTypesRepository fineTypesRepository;
        private ISensorsRepository sensorsRepository;
        private ISensorTypesRepository sensorTypesRepository;
        private ITechnicsRepository technicsRepository;
        private ITechnicTypesRepository technicTypesRepository;
        private IUsersRepository usersRepository;

        public DataManager(ICitiesRepository citiesRepository, IFinesRepository finesRepository,
            IFineTypesRepository fineTypesRepository, ISensorsRepository sensorsRepository,
            ISensorTypesRepository sensorTypesRepository, ITechnicsRepository technicsRepository,
            ITechnicTypesRepository technicTypesRepository, IUsersRepository usersRepository)
        {
            this.citiesRepository = citiesRepository;
            this.finesRepository = finesRepository;
            this.fineTypesRepository = fineTypesRepository;
            this.sensorsRepository = sensorsRepository;
            this.sensorTypesRepository = sensorTypesRepository;
            this.technicsRepository = technicsRepository;
            this.technicTypesRepository = technicTypesRepository;
            this.usersRepository = usersRepository;
        }

        public ICitiesRepository CitiesRepository { get{ return citiesRepository;} }
        public IFinesRepository FinesRepository
        {
            get { return finesRepository; }
        }
        public IFineTypesRepository FineTypesRepository
        {
            get { return fineTypesRepository; }
        }
        public ISensorsRepository SensorsRepository
        {
            get { return sensorsRepository; }
        }
        public ISensorTypesRepository SensorTypesRepository
        {
            get { return sensorTypesRepository; }
        }
        public ITechnicsRepository TechnicsRepository
        {
            get { return technicsRepository; }
        }
        public ITechnicTypesRepository TechnicTypesRepository
        {
            get { return technicTypesRepository; }
        }
        public IUsersRepository UsersRepository
        {
            get { return usersRepository; }
        }
    }
}
