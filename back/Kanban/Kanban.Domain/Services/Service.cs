using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces.Repository;
using Kanban.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Services
{

    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        protected readonly IRepository<TEntity> repository;
        public Service(IRepository<TEntity> repository)

        {
            this.repository = repository;
        }
        public int Update(TEntity obj)
        {
            return repository.Update(obj);
        }
        public void Delete(int id)

        {
            repository.Delete(id);
        }
        public void Delete(TEntity obj)
        {
            repository.Delete(obj);
        }
        public int Add(TEntity obj)
        {
            return repository.Add(obj);
        }
        public TEntity Get(int id)
        {
            return repository.Get(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

    }

}
