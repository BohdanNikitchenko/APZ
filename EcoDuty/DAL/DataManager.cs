using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;

namespace DAL
{
    public class DataManager
    {
        private ICitiesRepository citiesRepository;
        private IFinesRepository finesRepository;
        private ISensorsRepository sensorsRepository;
        private ISensorTypesRepository sensorTypesRepository;
        private ITechnicsRepository technicsRepository;
        private ITechnicTypesRepository technicTypesRepository;
        private IUsersRepository usersRepository;
        private IPlaceRepository placesRepository;
        private IPlaceTypeRepository placeTypesRepository;
        private ICryptoRepository cryptoRepository;

        public DataManager(ICitiesRepository citiesRepository, IFinesRepository finesRepository,
            ISensorsRepository sensorsRepository,
            ISensorTypesRepository sensorTypesRepository, ITechnicsRepository technicsRepository,
            ITechnicTypesRepository technicTypesRepository, IUsersRepository usersRepository,
            IPlaceRepository placesRepository, IPlaceTypeRepository placeTypesRepository,
            ICryptoRepository cryptoRepository)
        {
            this.citiesRepository = citiesRepository;
            this.finesRepository = finesRepository;
            this.sensorsRepository = sensorsRepository;
            this.sensorTypesRepository = sensorTypesRepository;
            this.technicsRepository = technicsRepository;
            this.technicTypesRepository = technicTypesRepository;
            this.usersRepository = usersRepository;
            this.placesRepository = placesRepository;
            this.placeTypesRepository = placeTypesRepository;
            this.cryptoRepository = cryptoRepository;
        }

        public ICitiesRepository CitiesRepository { get{ return citiesRepository;} }
        public IFinesRepository FinesRepository
        {
            get { return finesRepository; }
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

        public IPlaceRepository PlacesRepository
        {
            get { return placesRepository; }
        }

        public IPlaceTypeRepository PlaceTypesRepository
        {
            get { return placeTypesRepository; }
        }

        public ICryptoRepository CryptoRepository
        {
            get { return cryptoRepository; }
        }
    }
}
