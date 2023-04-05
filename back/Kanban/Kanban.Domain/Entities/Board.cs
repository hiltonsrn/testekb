using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Entities
{
    public class Board : Entity
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Quadrant> Quadrants { get; set; }
    }
}
