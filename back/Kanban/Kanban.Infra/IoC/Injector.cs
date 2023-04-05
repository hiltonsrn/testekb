using Kanban.Application.DTO;
using Kanban.Application.Interfaces;
using Kanban.Application.Services;
using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces;
using Kanban.Domain.Interfaces.Repository;
using Kanban.Domain.Interfaces.Services;
using Kanban.Domain.Services;
using Kanban.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Infra.IoC
{
    public class Injector
    {
        public static void Register(IServiceCollection svcCollection)
        {
            //Aplicação
            svcCollection.AddScoped(typeof(IApp<,>), typeof(App< ,  >));
            svcCollection.AddScoped<IBoardApp, BoardApp>();
            //Domínio
            svcCollection.AddScoped(typeof(IService<>), typeof(Service<>));
            svcCollection.AddScoped<IBoardService, BoardService>();
            //Repositorio
            svcCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            svcCollection.AddScoped<IBoardRepository, BoardRepository>();
        }
    }
}
