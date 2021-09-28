using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Repository
{
    public class Provider : IProvider
    {
        public DbContext currentDbContext { get; set; }
        protected Dictionary<Type, object> Repositories { get; private set; }

        public Provider()
        {
            Repositories = new Dictionary<Type, object>();
        }
        public IRepository<TEntity> Repo<TEntity>() where TEntity : class
        {
            object repoOut = null;
            this.Repositories.TryGetValue(typeof(IRepository<TEntity>), out repoOut);
            IRepository<TEntity> repo = repoOut as IRepository<TEntity>;
            if (repo == null)
            {
                IRepository<TEntity> obj = new Repository<TEntity>(currentDbContext);
                this.Repositories[typeof(IRepository<TEntity>)] = (object)obj;
                repo = obj;
            }
            return repo;
        }
    }
}
