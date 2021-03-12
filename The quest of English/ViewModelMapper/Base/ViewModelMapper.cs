using AutoMapper;
using System.Collections.Generic;

namespace TheEnglishQuestCore
{
    public class ViewModelMapper<EntityDto, EntityViewModel>
    {
        private IMapper _Mapper;

        public ViewModelMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<EntityDto, EntityViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }
        public EntityViewModel Map(EntityDto position) => _Mapper.Map<EntityViewModel>(position);
        public IEnumerable<EntityViewModel> Map(IEnumerable<EntityDto> positions) => _Mapper.Map<IEnumerable<EntityViewModel>>(positions);
        public EntityDto Map(EntityViewModel position) => _Mapper.Map<EntityDto>(position);
        public IEnumerable<EntityDto> Map(IEnumerable<EntityViewModel> positions) => _Mapper.Map<IEnumerable<EntityDto>>(positions);

    }
}