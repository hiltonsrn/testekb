using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Interfaces
{
    public interface IBoardRepository : IRepository<Board>
    {
        Board FiltraBoard(int BoardId, string filtro);
        Board GetBoard(int id);
        Board GetBoardFromQuadrant(int idQuadrant);
    }
}
