using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Application.DTO
{
    public class CardDTO : DTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public QuadrantDTO Quadrant { get; set; }
        public ResourceDTO Resource { get; set; }
        public SquadDTO Squad { get; set; }
        public DateTime? Prevision { get; set; }
        public TimeSpan Effort { get; set; }
        public string Status { get; set; }
        public TimeSpan Balance { get; set; }
    }
}
