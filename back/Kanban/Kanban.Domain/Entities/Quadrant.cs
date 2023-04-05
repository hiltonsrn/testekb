using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Entities
{
    public class Quadrant : Entity
    {
        public string Name { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; set; }
        public ICollection<Domain.Entities.Card> Cards { get; set; }
    }
}
