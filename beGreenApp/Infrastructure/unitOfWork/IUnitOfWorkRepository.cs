using beGreen.Model.Entity.Interfaces;
using System.Threading.Tasks;

namespace beGreen.Infrastructures.UnitOfWork
{
    public interface IUnitOfWorkRepository<T>
    {
        Task<bool> PersistCreationAsync(IEntity<T> entity);

        Task<bool> PersistUpdateAsync(IEntity<T> entity);

        Task<bool> PersistDeletionAsync(IEntity<T> entity);
    }
}
