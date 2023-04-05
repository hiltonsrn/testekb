using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces;
using Kanban.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Infra.Data.Repository
{
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        public ResourceRepository(KanbanContext contexto)
        : base(contexto)
        {
        }

        public Resource GetResource(string login, string password)
        {
            return (from r in contexto.Set<Resource>()
                    where r.Login == login && r.Password == password
                    select r).FirstOrDefault();
        }
    }
}
