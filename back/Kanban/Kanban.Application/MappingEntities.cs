using AutoMapper;
using Kanban.Application.DTO;
using Kanban.Domain.Entities;

namespace Kanban.Application
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<Board, BoardDTO>();
            CreateMap<BoardDTO, Board>();
            CreateMap<Domain.Entities.Quadrant, QuadrantDTO>();
            CreateMap<QuadrantDTO, Domain.Entities.Quadrant>();
            CreateMap<Domain.Entities.Card, CardDTO>();
            CreateMap<CardDTO, Domain.Entities.Card>();
            CreateMap<Resource, ResourceDTO>();
            CreateMap<ResourceDTO, Resource>();
            CreateMap<Squad, SquadDTO>();
            CreateMap<SquadDTO, Squad>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
