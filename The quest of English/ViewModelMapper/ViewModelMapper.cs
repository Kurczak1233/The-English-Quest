using AutoMapper;
using System.Collections.Generic;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase;
using The_quest_of_English.Models;

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
        public List<EncouragementPositionViewModel> Map(List<EncouragementPositionDto> positions) => _Mapper.Map<List<EncouragementPositionViewModel>>(positions);
        public EncouragementPositionDto Map(EncouragementPositionViewModel position) => _Mapper.Map<EncouragementPositionDto>(position);
        public List<EncouragementPositionDto> Map(List<EncouragementPositionViewModel> positions) => _Mapper.Map<List<EncouragementPositionDto>>(positions);

    }
}