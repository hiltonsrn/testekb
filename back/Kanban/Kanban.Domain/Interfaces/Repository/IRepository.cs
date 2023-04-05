using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Delete(int id);
        void Delete(T obj);
        int Add(T obj);
        int Update(T obj);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
