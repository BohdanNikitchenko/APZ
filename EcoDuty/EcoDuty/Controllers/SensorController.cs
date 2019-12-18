using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Models;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoDuty.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private DataManager datamanager;
        private ServiceManager servicesmanager;

        public SensorController(DataManager dataManager)
        {
            datamanager = dataManager;
            servicesmanager = new ServiceManager(dataManager);
        }

        // POST: api/Sensor 
        [HttpPost]
        public void PostSensor(SensorAPIModel model)
        {
            servicesmanager.Sensor.SensorPOST(model);
        }
    }
}