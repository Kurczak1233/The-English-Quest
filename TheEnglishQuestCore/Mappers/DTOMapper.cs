using AutoMapper;
using System.Collections.Generic;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase;
namespace TheEnglishQuestCore
{
    public class DTOMapper
    {
        private readonly IMapper _Mapper;

        public DTOMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<EncouragementPosition, EncouragementPositionDto>()
                .ReverseMap();
            }).CreateMapper();
        }
        public EncouragementPositionDto Map(EncouragementPosition position) => _Mapper.Map<EncouragementPositionDto>(position);
        public List<EncouragementPositionDto> Map(List<EncouragementPosition> positions) => _Mapper.Map<List<EncouragementPositionDto>>(positions);
        public EncouragementPosition Map(EncouragementPositionDto position) => _Mapper.Map<EncouragementPosition>(position);
        public List<EncouragementPosition> Map(List<EncouragementPositionDto> positions) => _Mapper.Map<List<EncouragementPosition>>(positions);

    }
}