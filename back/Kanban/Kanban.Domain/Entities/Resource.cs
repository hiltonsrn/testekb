using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Entities
{
    public class Resource : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Acronym => $"{Name.First()}{LastName.First()}".ToUpper();
        public string Login { get; set; }
        public string Password { get; set; }
        public int SquadId { get; set; }
        public Squad Squad { get; set; }
        public ICollection<Entities.Card> Cards { get; set; }
    }
}
