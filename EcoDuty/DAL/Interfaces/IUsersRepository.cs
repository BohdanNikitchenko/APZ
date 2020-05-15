using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DAL.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        //User FindUserByPassport(string passport);
        User Find(Func<User, Boolean> predicate);
        //User FindRegisteredUser(string passport, string password);
    }
}
