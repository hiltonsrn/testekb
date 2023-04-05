using AutoMapper;
using Kanban.Application.Interfaces;
using Kanban.Domain.Entities;
using Kanban.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Application.Services
{
    public class App<TEntity, TDTO> : IApp<TEntity, TDTO>
 where TEntity : Entity
 where TDTO : DTO.DTO
    {
        protected readonly IService<TEntity> service;
        protected readonly IMapper iMapper;
        public App(IMapper iMapper, IService<TEntity> service)
        : base()
        {
            this.iMapper = iMapper;
            this.service = service;
        }
        public int Update(TDTO entidade)
        {
            return service.Update(iMapper.Map<TEntity>(entidade));
        }
        public void Delete(int id)
        {
            service.Delete(id);
        }
        public void Delete(TDTO entidade)
        {
            service.Delete(iMapper.Map<TEntity>(entidade));
        }
        public int Add(TDTO entidade)
        {
            return service.Add(iMapper.Map<TEntity>(entidade));
        }
        public TDTO Get(int id)
        {
            return iMapper.Map<TDTO>(service.Get(id));
        }
        public IEnumerable<TDTO> GetAll()
        {
            return iMapper.Map<IEnumerable<TDTO>>(service.GetAll());
        }
    }
}