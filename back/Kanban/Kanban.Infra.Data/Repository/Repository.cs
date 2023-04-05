using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces.Repository;
using Kanban.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Infra.Data.Repository
{
public class Repository<TEntity> : IRepository<TEntity>
 where TEntity : Entity
    {
        protected readonly KanbanContext contexto;
        public Repository(KanbanContext contexto)

        : base()

        {

            this.contexto = contexto;

        }
        public int Update(TEntity entidade)

        {
            contexto.InitTransacao();

            contexto.Set<TEntity>().Attach(entidade);

            contexto.Entry(entidade).State = EntityState.Modified;

            contexto.SendChanges();
            return entidade.Id;
        }

        public void Delete(int id)

        {
            var entidade = Get(id);
            if (entidade != null)

            {
                contexto.InitTransacao();
                contexto.Set<TEntity>().Remove(entidade);
                contexto.SendChanges();
            }

        }
        public void Delete(TEntity entidade)
        {
            contexto.InitTransacao();
            contexto.Set<TEntity>().Remove(entidade);
            contexto.SendChanges();
        }

        public int Add(TEntity entidade)
        {
            contexto.InitTransacao();
            var id = contexto.Set<TEntity>().Add(entidade).Entity.Id;
            contexto.SendChanges();
            return id;
        }
        public TEntity Get(int id)
        {
            return contexto.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return contexto.Set<TEntity>().ToList();
        }

    }

}
