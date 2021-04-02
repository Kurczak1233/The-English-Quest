using AutoMapper;
using System.Collections.Generic;

namespace The_quest_of_English
{
    public class ViewModelMapper3<EntityDto1, EntityViewModel1, EntityDto2, EntityViewModel2, EntityDto3, EntityViewModel3>
    {
        private readonly IMapper _Mapper;

        public ViewModelMapper3()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<EntityDto1, EntityViewModel1>()
                .ReverseMap();
                config.CreateMap<EntityDto2, EntityViewModel2>()
                .ReverseMap();
                config.CreateMap<EntityDto3, EntityViewModel3>()
                .ReverseMap();
            }).CreateMapper();
        }
        public EntityViewModel1 Map(EntityDto1 position) => _Mapper.Map<EntityViewModel1>(position);
        public IEnumerable<EntityViewModel1> Map(IEnumerable<EntityDto1> positions) => _Mapper.Map<IEnumerable<EntityViewModel1>>(positions);
        public EntityDto1 Map(EntityViewModel1 position) => _Mapper.Map<EntityDto1>(position);
        public IEnumerable<EntityDto1> Map(IEnumerable<EntityViewModel1> positions) => _Mapper.Map<IEnumerable<EntityDto1>>(positions);

        public EntityViewModel2 Map(EntityDto2 position) => _Mapper.Map<EntityViewModel2>(position);
        public IEnumerable<EntityViewModel2> Map(IEnumerable<EntityDto2> positions) => _Mapper.Map<IEnumerable<EntityViewModel2>>(positions);
        public EntityDto2 Map(EntityViewModel2 position) => _Mapper.Map<EntityDto2>(position);
        public IEnumerable<EntityDto2> Map(IEnumerable<EntityViewModel2> positions) => _Mapper.Map<IEnumerable<EntityDto2>>(positions);

        public EntityViewModel3 Map(EntityDto3 position) => _Mapper.Map<EntityViewModel3>(position);
        public IEnumerable<EntityViewModel3> Map(IEnumerable<EntityDto3> positions) => _Mapper.Map<IEnumerable<EntityViewModel3>>(positions);
        public EntityDto3 Map(EntityViewModel3 position) => _Mapper.Map<EntityDto3>(position);
        public IEnumerable<EntityDto3> Map(IEnumerable<EntityViewModel3> positions) => _Mapper.Map<IEnumerable<EntityDto3>>(positions);
    }
}