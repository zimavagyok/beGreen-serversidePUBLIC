using beGreen.Infrastructures.UnitOfWork;
using beGreen.Model.Entity.Interfaces;

namespace beGreen.Infrastructure.unitOfWork
{
    public interface IUnitOfWork<T>
    {
        void RegisterUpdated(IEntity<T> entity, IUnitOfWorkRepository<T> unitofWorkRepository);

        void RegisterNew(IEntity<T> entity, IUnitOfWorkRepository<T> unitofWorkRepository);

        void RegisterRemoved(IEntity<T> entity, IUnitOfWorkRepository<T> unitofWorkRepository);

        void Commit();
    }
}
