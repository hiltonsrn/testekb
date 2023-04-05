using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Interfaces
{
    public interface IResourceRepository : IRepository<Resource>
    {
        Resource GetResource(string login, string password);
    }
}
