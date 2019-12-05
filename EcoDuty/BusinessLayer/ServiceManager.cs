using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Services;
using DAL;

namespace BusinessLayer
{
    public class ServiceManager
    {
        private DataManager dataManager;
        private UserService userService;

        public ServiceManager(DataManager dataManager)
        {
            this.dataManager = dataManager;
            userService = new UserService(dataManager);
        }
        public UserService Users { get { return userService; } }

    }
}
