using Kanban.Application.DTO;
using Kanban.Application.DTO;
using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Application.Interfaces
{
    public interface IApp<TEntity, TDTO> where TEntity : Entity where TDTO : DTO.DTO
    {
        void Delete(int id);
        void Delete(TDTO obj);
        int Add(TDTO obj);
        int Update(TDTO obj);
        TDTO Get(int id);
        IEnumerable<TDTO> GetAll();
    }
}
