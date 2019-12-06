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
        private AdminService adminService;

        public ServiceManager(DataManager dataManager)
        {
            this.dataManager = dataManager;
            userService = new UserService(dataManager);
            adminService = new AdminService(dataManager);
        }
        public UserService Users { get { return userService; } }
        public AdminService Admin { get { return adminService; } }
    }
}
