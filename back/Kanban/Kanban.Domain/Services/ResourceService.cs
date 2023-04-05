using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces;
using Kanban.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Services
{
    public class ResourceService : Service<Resource>, IResourceService
    {
        public ResourceService(IResourceRepository repository)
        : base(repository)
        {

        }

        public Resource GetResource(string login, string password)
        {
            return ((IResourceRepository)repository).GetResource(login, password);
        }
    }
}
