using AutoMapper;
using System.Collections.Generic;

namespace TheEnglishQuestCore
{
    public class DTOMapper3<Entity1, EntityDto1, Entity2, EntityDto2, Entity3, EntityDto3>
    {
        private readonly IMapper _Mapper;

        public DTOMapper3()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Entity1, EntityDto1>()
                .ReverseMap();
                config.CreateMap<Entity2, EntityDto2>()
                .ReverseMap();
                config.CreateMap<Entity3, EntityDto3>()
                .ReverseMap();
            }).CreateMapper();
        }
        public EntityDto1 Map(Entity1 position) => _Mapper.Map<EntityDto1>(position);
        public IEnumerable<EntityDto1> Map(IEnumerable<Entity1> positions) => _Mapper.Map<IEnumerable<EntityDto1>>(positions);
        public Entity1 Map(EntityDto1 position) => _Mapper.Map<Entity1>(position);
        public IEnumerable<Entity1> Map(IEnumerable<EntityDto1> positions) => _Mapper.Map<IEnumerable<Entity1>>(positions);

        public EntityDto2 Map(Entity2 position) => _Mapper.Map<EntityDto2>(position);
        public IEnumerable<EntityDto2> Map(IEnumerable<Entity2> positions) => _Mapper.Map<IEnumerable<EntityDto2>>(positions);
        public Entity2 Map(EntityDto2 position) => _Mapper.Map<Entity2>(position);
        public IEnumerable<Entity2> Map(IEnumerable<EntityDto2> positions) => _Mapper.Map<IEnumerable<Entity2>>(positions);

        public EntityDto3 Map(Entity3 position) => _Mapper.Map<EntityDto3>(position);
        public IEnumerable<EntityDto3> Map(IEnumerable<Entity3> positions) => _Mapper.Map<IEnumerable<EntityDto3>>(positions);
        public Entity3 Map(EntityDto3 position) => _Mapper.Map<Entity3>(position);
        public IEnumerable<Entity3> Map(IEnumerable<EntityDto3> positions) => _Mapper.Map<IEnumerable<Entity3>>(positions);
    }
}
