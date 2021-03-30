using AutoMapper;
using System.Collections.Generic;
using TheEnglishQuestCore;
using TheEnglishQuestDatabase.Entities;

namespace The_quest_of_English
{
    public class GrammarQuizViewModelMapper : ViewModelMapper<GrammarQuizDto, GrammarQuizViewModel>
    {
        //private readonly IMapper _Mapper;

        //public GrammarQuizViewModelMapper()
        //{
        //    _Mapper = new MapperConfiguration(config =>
        //    {
        //        config.CreateMap<GrammarQuizDto, GrammarQuizViewModel>()
        //        .ReverseMap();
        //        config.CreateMap<ApplicationUserDto, ApplicationUserViewModelMapper>()
        //        .ReverseMap();
        //    }).CreateMapper();
        //}
        //public GrammarQuizViewModel Map(GrammarQuizDto position) => _Mapper.Map<GrammarQuizViewModel>(position);
        //public IEnumerable<GrammarQuizViewModel> Map(IEnumerable<GrammarQuizDto> positions) => _Mapper.Map<IEnumerable<GrammarQuizViewModel>>(positions);
        //public GrammarQuizDto Map(GrammarQuizViewModel position) => _Mapper.Map<GrammarQuizDto>(position);
        //public IEnumerable<GrammarQuizDto> Map(IEnumerable<GrammarQuizViewModel> positions) => _Mapper.Map<IEnumerable<GrammarQuizDto>>(positions);

        //public ApplicationUserViewModelMapper Map(ApplicationUserDto position) => _Mapper.Map<ApplicationUserViewModelMapper>(position);
        //public IEnumerable<ApplicationUserViewModelMapper> Map(IEnumerable<ApplicationUserDto> positions) => _Mapper.Map<IEnumerable<ApplicationUserViewModelMapper>>(positions);
        //public ApplicationUserDto Map(ApplicationUserViewModelMapper position) => _Mapper.Map<ApplicationUserDto>(position);
        //public IEnumerable<ApplicationUserDto> Map(IEnumerable<ApplicationUserViewModelMapper> positions) => _Mapper.Map<IEnumerable<ApplicationUserDto>>(positions);
    }
}
