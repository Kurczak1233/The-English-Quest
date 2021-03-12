using AutoMapper;
using System.Collections.Generic;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class DTOMapper<Entity, EntityDto>
    {
        private readonly IMapper _Mapper;
        
        public DTOMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Entity, EntityDto>()
                .ReverseMap();
            }).CreateMapper();
        }
        public EntityDto Map(Entity position) => _Mapper.Map<EntityDto>(position);
        public IEnumerable<EntityDto> Map(IEnumerable<Entity> positions) => _Mapper.Map<IEnumerable<EntityDto>>(positions);
        public Entity Map(EntityDto position) => _Mapper.Map<Entity>(position);
        public IEnumerable<Entity> Map(IEnumerable<EntityDto> positions) => _Mapper.Map<IEnumerable<Entity>>(positions);
    }
}