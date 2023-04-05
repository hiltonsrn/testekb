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
    public class BoardApp : App<Board, BoardDTO>, IBoardApp
    {
        public BoardApp(IMapper iMapper, IBoardService service)
        : base(iMapper, service)
        {

        }

        public BoardDTO FiltraBoard(int BoardId, string filtro)
        {
            return iMapper.Map<BoardDTO>(((IBoardService)service).FiltraBoard(BoardId, filtro));
        }

        public BoardDTO GetBoard(int id)
        {
            return iMapper.Map<BoardDTO>(((IBoardService)service).GetBoard(id));
        }
        public BoardDTO MovCard(MovCardDTO dto)
        {
            return iMapper.Map<BoardDTO>(((IBoardService)service).MovCard(dto.IdQuadrant, dto.IdCard));
        }
    }
}
