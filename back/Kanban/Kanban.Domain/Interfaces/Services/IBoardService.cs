using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Interfaces.Services
{
    public interface IBoardService : IService<Board>
    {
        Board FiltraBoard(int BoardId, string filtro);
        Board GetBoard(int id);
        Board MovCard(int IdQuadrant, int IdCard);
    }
}
