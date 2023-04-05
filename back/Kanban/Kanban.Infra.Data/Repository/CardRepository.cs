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
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(KanbanContext contexto)
        : base(contexto)
        {
        }
    }
}
