using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class EFUsersRepository : IUsersRepository
    {
        private EFDBContext context;
        public EFUsersRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<User> GetList()
        {
            return context.Set<User>()
                .Include(x => x.City)
                .Include(x => x.Sensors)
                .Include(x => x.Technics)
                .Include(x => x.Places)
                .AsNoTracking().ToList();
        }

        public User GetItem(int id)
        {
            return context.Set<User>()
                .Include(x => x.City)
                .Include(x => x.Sensors)
                .Include(x => x.Technics)
                .Include(x => x.Places)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Create(User item)
        {
            context.Users.Add(item);
            context.SaveChanges();
        }

        public void Update(User item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = context.Find<User>(id);
            if (user != null)
            {
                context.Users.Remove(user);
            }
            context.SaveChanges();
        }

        //public User FindUserByPassport(string passport)
        //{
        //    return context.Set<User>()
        //        .Include(x => x.City)
        //        .Include(x => x.Sensors)
        //        .Include(x => x.Technics)
        //        .Include(x => x.Places)
        //        .FirstOrDefault(x => x.Passport == passport);
        //}
        public User Find(Func<User, bool> predicate)
        {
            return context.Set<User>().Include(x => x.City)
                .Include(x => x.Sensors)
                .Include(x => x.Technics)
                .Include(x => x.Places)
                .FirstOrDefault(predicate);
        }
        //public User FindRegisteredUser(string passport, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

