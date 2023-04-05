using Kanban.Application.DTO;
using Kanban.Application.Interfaces;
using Kanban.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    public class BoardController : ControllerBase<Board, BoardDTO>
    {
        public BoardController(IBoardApp app)
            : base(app)
        { }
        [HttpGet]
        [Route("GetBoard/{id}")]
        public IActionResult GetBoard(int id)
        {
            try
            {
                var board = ((IBoardApp)app).GetBoard(id);
                return new OkObjectResult(board);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("FiltraBoard/{id}/{filtro}")]
        public IActionResult FiltraBoard(int id, string filtro)
        {
            try
            {
                var board = ((IBoardApp)app).FiltraBoard(id, filtro);
                return new OkObjectResult(board);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("MovCard")]
        public IActionResult MovCard([FromBody] MovCardDTO dto)
        {
            try
            {
                var board = ((IBoardApp)app).MovCard(dto);
                return new OkObjectResult(board);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
