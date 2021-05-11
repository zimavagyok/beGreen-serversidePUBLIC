using System.Collections.Generic;
using System;
using System.Transactions;
using beGreen.Infrastructure.unitOfWork;
using beGreen.Model.Entity.Interfaces;

namespace beGreen.Infrastructures.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T>
    {
        private Dictionary<IEntity<T>, IUnitOfWorkRepository<T>> AddedEntities;
        private Dictionary<IEntity<T>, IUnitOfWorkRepository<T>> ChangedEntities;
        private Dictionary<IEntity<T>, IUnitOfWorkRepository<T>> DeletedEntities;

        public UnitOfWork()
        {
            AddedEntities = new Dictionary<IEntity<T>, IUnitOfWorkRepository<T>>();

            ChangedEntities = new Dictionary<IEntity<T>, IUnitOfWorkRepository<T>>();

            DeletedEntities = new Dictionary<IEntity<T>, IUnitOfWorkRepository<T>>();
        }

        public void RegisterUpdated(IEntity<T> entity, IUnitOfWorkRepository<T> unitofWorkRepository)
        {
            if (!ChangedEntities.ContainsKey(entity))
            {
                ChangedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void RegisterNew(IEntity<T> entity, IUnitOfWorkRepository<T> unitofWorkRepository)
        {
            if (!AddedEntities.ContainsKey(entity))
            {
                AddedEntities.Add(entity, unitofWorkRepository);
            };
        }

        public void RegisterRemoved(IEntity<T> entity, IUnitOfWorkRepository<T> unitofWorkRepository)
        {
            if (!DeletedEntities.ContainsKey(entity))
            {
                DeletedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IEntity<T> entity in this.AddedEntities.Keys)
                {
                    this.AddedEntities[entity].PersistCreationAsync(entity);
                }

                foreach (IEntity<T> entity in this.ChangedEntities.Keys)
                {
                    this.ChangedEntities[entity].PersistUpdateAsync(entity);
                }

                foreach (IEntity<T> entity in this.DeletedEntities.Keys)
                {
                    this.DeletedEntities[entity].PersistDeletionAsync(entity);
                }

                scope.Complete();
            }

            AddedEntities.Clear();
            ChangedEntities.Clear();
            DeletedEntities.Clear();
        }
    }
}
