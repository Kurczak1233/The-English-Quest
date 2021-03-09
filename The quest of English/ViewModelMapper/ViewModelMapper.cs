using AutoMapper;
using System.Collections.Generic;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase;
using The_quest_of_English.Models;
using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public class ViewModelMapper
    {
        private IMapper _Mapper;

        public ViewModelMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<EncouragementPositionDto, EncouragementPositionViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }
        public EncouragementPositionViewModel Map(EncouragementPositionDto position) => _Mapper.Map<EncouragementPositionViewModel>(position);
        public IEnumerable<EncouragementPositionViewModel> Map(IEnumerable<EncouragementPositionDto> positions) => _Mapper.Map<IEnumerable<EncouragementPositionViewModel>>(positions);
        public EncouragementPositionDto Map(EncouragementPositionViewModel position) => _Mapper.Map<EncouragementPositionDto>(position);
        public IEnumerable<EncouragementPositionDto> Map(IEnumerable<EncouragementPositionViewModel> positions) => _Mapper.Map<IEnumerable<EncouragementPositionDto>>(positions);
        //public Task<EncouragementPositionViewModel> Map(Task<EncouragementPositionDto> position) => _Mapper.Map<Task<EncouragementPositionViewModel>>(position);
        //public Task<IEnumerable<EncouragementPositionViewModel>> Map(Task<IEnumerable<EncouragementPositionDto>> positions) => _Mapper.Map<Task<IEnumerable<EncouragementPositionViewModel>>>(positions);
        //public Task<EncouragementPositionDto> Map(Task<EncouragementPositionViewModel> position) => _Mapper.Map<Task<EncouragementPositionDto>>(position);
        //public Task<IEnumerable<EncouragementPositionDto>> Map(Task<IEnumerable<EncouragementPositionViewModel>> positions) => _Mapper.Map<Task<IEnumerable<EncouragementPositionDto>>>(positions);

    }
}