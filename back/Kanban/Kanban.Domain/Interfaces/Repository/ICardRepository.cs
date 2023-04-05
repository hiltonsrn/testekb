using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {        
    }
}
