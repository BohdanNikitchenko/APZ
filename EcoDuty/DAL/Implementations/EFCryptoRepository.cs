using CryptoDataLayer;
using CryptoDataLayer.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Implementations
{
    public class EFCryptoRepository : ICryptoRepository
    {
        private CryptoDBContext context;
        public EFCryptoRepository(CryptoDBContext context)
        {
            this.context = context;
        }
        public void Create(Crypto item)
        {
            context.Cryptos.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Crypto crypto = context.Find<Crypto>(id);
            if (crypto != null)
            {
                context.Cryptos.Remove(crypto);
            }
            context.SaveChanges();
        }

        public Crypto GetItem(int id)
        {
            return context.Set<Crypto>()
               .AsNoTracking()
               .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Crypto> GetList()
        {
            return context.Set<Crypto>()
                .AsNoTracking().ToList();
        }

        public string GetPassByuserId(int userId)
        {
            return context.Set<Crypto>()
                .AsNoTracking()
                .FirstOrDefault(x => x.UserId == userId).Pass;
        }

        public void Update(Crypto item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
