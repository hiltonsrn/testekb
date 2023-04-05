using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Application.DTO
{
    public class SquadDTO : DTO
    {
        public string Name { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
        public ICollection<ResourceDTO> Resources { get; set; }
    }
}
