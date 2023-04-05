using Kanban.Application.DTO;
using Kanban.Application.Interfaces;
using Kanban.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    public class ResourceController : ControllerBase<Resource, ResourceDTO>
    {
        public ResourceController(IResourceApp app)
            : base(app)
        { }
        [HttpGet]
        [Route("GetResource/{login}/{password}")]
        public IActionResult GetResource(string login, string password)
        {
            try
            {
                var resource = ((IResourceApp)app).GetResource(login, password);
                return new OkObjectResult(resource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
