using AutoMapper;
using System.Collections.Generic;
using TheEnglishQuest;
using TheEnglishQuestCore;
using TheEnglishQuestDatabase.Entities;

namespace The_quest_of_English
{
    public class GrammarQuizViewModelMapper : ViewModelMapper3<GrammarQuizDto, GrammarQuizViewModel,
        ApplicationUserDto, ApplicationUserViewModel, ListeningTaskDto, GrammarTasksViewModel> 
    {
        //private readonly IMapper _Mapper;

        //public GrammarQuizViewModelMapper()
        //{
        //    _Mapper = new MapperConfiguration(config =>
        //    {
        //        config.CreateMap<GrammarQuizDto, GrammarQuizViewModel>()
        //        .ReverseMap();
        //        config.CreateMap<ApplicationUserDto, ApplicationUserViewModel>()
        //        .ReverseMap();
        //        config.CreateMap<GrammarTaskDto, GrammarTasksViewModel>()
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

        //public GrammarTasksViewModel Map(GrammarTaskDto position) => _Mapper.Map<GrammarTasksViewModel>(position);
        //public IEnumerable<GrammarTasksViewModel> Map(IEnumerable<GrammarTaskDto> positions) => _Mapper.Map<IEnumerable<GrammarTasksViewModel>>(positions);
        //public GrammarTaskDto Map(GrammarTasksViewModel position) => _Mapper.Map<GrammarTaskDto>(position);
        //public IEnumerable<GrammarTaskDto> Map(IEnumerable<GrammarTasksViewModel> positions) => _Mapper.Map<IEnumerable<GrammarTaskDto>>(positions);
    }
}
