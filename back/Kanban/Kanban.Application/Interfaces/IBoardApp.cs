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
    public interface IBoardApp : IApp<Board,BoardDTO>
    {
        BoardDTO FiltraBoard(int BoardId, string filtro);
        BoardDTO GetBoard(int id);
        BoardDTO MovCard(MovCardDTO dto);
    }
}
