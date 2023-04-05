using Kanban.Application.DTO;
using Kanban.Application.DTO;
using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Application.Interfaces
{
    public interface IResourceApp : IApp<Resource, ResourceDTO>
    {
        ResourceDTO GetResource(string login, string password);
    }
}
