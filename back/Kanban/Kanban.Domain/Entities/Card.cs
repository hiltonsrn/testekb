using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Entities
{
    public class Card : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuadrantId { get; set; }
        public Quadrant Quadrant { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public int SquadId { get; set; }
        public Squad Squad { get; set; }
        public DateTime? Prevision { get; set; }
        public TimeSpan Effort { get; set; }
        public TimeSpan Balance => Prevision.Value - DateTime.Now.Add(Effort);
        public string Status
        {
            get
            {
                if (Balance < new TimeSpan(0, 0, 0))
                {
                    return "Em Atraso";
                }
                else
                    return "Em dia";
            }

        }
    }
}
