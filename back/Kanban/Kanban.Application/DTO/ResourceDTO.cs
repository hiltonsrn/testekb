using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Application.DTO
{
    public class ResourceDTO : DTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Acronym { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}
