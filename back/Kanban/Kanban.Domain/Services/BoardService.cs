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
    public class BoardService : Service<Board>, IBoardService
    {
        ICardRepository cardRepository;
        public BoardService(IBoardRepository repository, ICardRepository cardRepository)
        : base(repository)
        {
            this.cardRepository = cardRepository;
        }

        public Board FiltraBoard(int BoardId, string filtro)
        {
            Board board = ((IBoardRepository)repository).FiltraBoard(BoardId, filtro);
            return board;
        }

        public Board GetBoard(int id)
        {
            Board board = ((IBoardRepository)repository).GetBoard(id);
            return board;
        }

        public Board MovCard(int IdQuadrant, int IdCard)
        {
            Card card = cardRepository.Get(IdCard);
            card.QuadrantId = IdQuadrant;
            cardRepository.Update(card);
            Board board = ((IBoardRepository)repository).GetBoardFromQuadrant(IdQuadrant);
            return board;
        }
    }
}
