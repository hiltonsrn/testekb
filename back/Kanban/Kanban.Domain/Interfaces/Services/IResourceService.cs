using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Interfaces.Services
{
    public interface IResourceService : IService<Resource>
    {
        Resource GetResource(string login, string password);
    }
}
