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
    public class BoardRepository : Repository<Board>, IBoardRepository
    {
        private string _filtro;
        public BoardRepository(KanbanContext contexto)
        : base(contexto)
        {
        }

        public Board FiltraBoard(int BoardId,string filtro)
        {
            _filtro = filtro;
            return GetBoard(BoardId);
        }

        public Board GetBoard(int id)
        {
            return (from b in contexto.Set<Board>()
                    join p in contexto.Set<Project>() on b.ProjectId equals p.Id
                    where b.Id == id
                   select new Board
                   {
                       Id = b.Id,
                       Name = b.Name,
                       Project = new Project
                       {
                           Id = p.Id,
                           Name = p.Name
                       },
                       Quadrants = (from q in contexto.Set<Quadrant>()
                                    where q.BoardId == b.Id
                                    select new Quadrant
                                    {
                                        Id = q.Id,
                                        Name= q.Name,
                                        Cards = (from c in contexto.Set<Card>()
                                                 where c.QuadrantId == q.Id
                                                 && (_filtro == null || (c.Name.Contains(_filtro) || c.Description.Contains(_filtro)))
                                                 select new Card
                                                 {
                                                     Id= c.Id,
                                                     Name= c.Name,
                                                     Description = c.Description,
                                                     Prevision = c.Prevision,
                                                     Effort = c.Effort,
                                                     Resource = (from r in contexto.Set<Resource>()
                                                                 where r.Id == c.ResourceId
                                                                 select r).FirstOrDefault(),
                                                     Squad = (from s in contexto.Set<Squad>() where s.Id == c.SquadId
                                                              select new Squad
                                                              {
                                                                  Id = s.Id,
                                                                  Name= s.Name,
                                                                  Resources = (from r in contexto.Set<Resource>()
                                                                               where r.SquadId == s.Id
                                                                               select r).ToList()
                                                              }).FirstOrDefault()
                                                 }).ToList()
                                    }).ToList()
                   }).FirstOrDefault();
                   
        }

        public Board GetBoardFromQuadrant(int idQuadrant)
        {
            var boardId = (from q in contexto.Set<Quadrant>()
                           where q.Id == idQuadrant
                           select q.BoardId).FirstOrDefault();
            return GetBoard(boardId);                           
        }
    }
}
