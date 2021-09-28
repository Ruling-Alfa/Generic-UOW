using System.Threading.Tasks;

namespace UsersApi.Repository
{
    public interface IUow
    {
        Task CommitAsync();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}