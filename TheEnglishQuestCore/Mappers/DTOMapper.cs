using AutoMapper;
using System.Collections.Generic;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase;
using System.Threading.Tasks;

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
        public IEnumerable<EncouragementPositionDto> Map(IEnumerable<EncouragementPosition> positions) => _Mapper.Map<IEnumerable<EncouragementPositionDto>>(positions);
        public EncouragementPosition Map(EncouragementPositionDto position) => _Mapper.Map<EncouragementPosition>(position);
        public IEnumerable<EncouragementPosition> Map(IEnumerable<EncouragementPositionDto> positions) => _Mapper.Map<IEnumerable<EncouragementPosition>>(positions);
        //public Task<EncouragementPositionDto> Map(Task<EncouragementPosition> position) => _Mapper.Map<Task<EncouragementPositionDto>>(position);
        //public Task<IEnumerable<EncouragementPositionDto>> Map(Task<IEnumerable<EncouragementPosition>> positions) => _Mapper.Map<Task<IEnumerable<EncouragementPositionDto>>>(positions);
        //public Task<EncouragementPosition> Map(Task<EncouragementPositionDto> position) => _Mapper.Map<Task<EncouragementPosition>>(position);
        //public Task<IEnumerable<EncouragementPosition>> Map(Task<IEnumerable<EncouragementPositionDto>> positions) => _Mapper.Map<Task<IEnumerable<EncouragementPosition>>>(positions);

    }
}