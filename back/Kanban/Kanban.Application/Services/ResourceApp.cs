using AutoMapper;
using Kanban.Application.DTO;
using Kanban.Application.Interfaces;
using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces.Services;
using Kanban.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Application.Services
{
    public class ResourceApp : App<Resource, ResourceDTO>, IResourceApp
    {
        public ResourceApp(IMapper iMapper, IResourceService service)
        : base(iMapper, service)
        {

        }

        public ResourceDTO GetResource(string login, string password)
        {
            return iMapper.Map<ResourceDTO>(((IResourceService)service).GetResource(login, password));
        }
    }
}
