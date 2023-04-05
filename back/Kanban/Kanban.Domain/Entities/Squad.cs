using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Entities
{
    public class Squad : Entity
    {
        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}
