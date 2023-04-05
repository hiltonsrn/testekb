using Kanban.Application.DTO;
using Kanban.Application.Interfaces;
using Kanban.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ControllerBase<TEntity, TDTO> : Controller
                                                 where TEntity : Entity
                                                 where TDTO : DTO
    {
        readonly protected IApp<TEntity, TDTO> app;
        public ControllerBase(IApp<TEntity, TDTO> app)
        {
            this.app = app;
        }

        [HttpGet]
        [Route("")]
        public IActionResult List()
        {
            try
            {
                return new OkObjectResult(app.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var restaurantes = app.Get(id);
                return new OkObjectResult(restaurantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult Save([FromBody] TDTO dado)
        {
            try
            {
                return new OkObjectResult(1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //app.Delete(id);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}