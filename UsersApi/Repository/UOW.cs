using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Repository
{
    public class Uow : IUow
    {
        private readonly DbContext dbContext;
        private readonly IProvider _provider;
        public Uow(IProvider provider)
        {
            dbContext = new UserContext();
            _provider = provider;
            provider.currentDbContext = dbContext;
           
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return  _provider.Repo<TEntity>();
        }

        public Task CommitAsync()
        {
            if (dbContext is null)
            {
                throw new ArgumentNullException($"{nameof(dbContext)} Context is null");
            }
            return dbContext.SaveChangesAsync();
        }

    }
}
