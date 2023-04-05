using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Application.DTO
{
    public class BoardDTO : DTO
    {
        public string Name { get; set; }
        public ProjectDTO Project { get; set; }
        public ICollection<QuadrantDTO> Quadrants { get; set; }
    }
}
