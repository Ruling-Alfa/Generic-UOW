using Microsoft.EntityFrameworkCore;

namespace UsersApi.Repository
{
    public interface IProvider
    {
        DbContext currentDbContext { get; set; }

        IRepository<TEntity> Repo<TEntity>() where TEntity : class;
    }
}