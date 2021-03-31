using AutoMapper;
using System.Collections.Generic;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class GrammarQuizMapper : DTOMapper<GrammarQuiz, GrammarQuizDto>
    {
        //private readonly IMapper _Mapper;

        //public GrammarQuizMapper()
        //{
        //    _Mapper = new MapperConfiguration(config =>
        //    {
        //        config.CreateMap<GrammarQuiz, GrammarQuizDto>()
        //        .ReverseMap();
        //        config.CreateMap<ApplicationUser, ApplicationUserDto>()
        //        .ReverseMap();
        //    }).CreateMapper();
        //}
        //public GrammarQuizDto Map(GrammarQuiz position) => _Mapper.Map<GrammarQuizDto>(position);
        //public IEnumerable<GrammarQuizDto> Map(IEnumerable<GrammarQuiz> positions) => _Mapper.Map<IEnumerable<GrammarQuizDto>>(positions);
        //public GrammarQuiz Map(GrammarQuizDto position) => _Mapper.Map<GrammarQuiz>(position);
        //public IEnumerable<GrammarQuiz> Map(IEnumerable<GrammarQuizDto> positions) => _Mapper.Map<IEnumerable<GrammarQuiz>>(positions);

        //public ApplicationUserDto Map(ApplicationUser position) => _Mapper.Map<ApplicationUserDto>(position);
        //public IEnumerable<ApplicationUserDto> Map(IEnumerable<ApplicationUser> positions) => _Mapper.Map<IEnumerable<ApplicationUserDto>>(positions);
        //public ApplicationUser Map(ApplicationUserDto position) => _Mapper.Map<ApplicationUser>(position);
        //public IEnumerable<ApplicationUser> Map(IEnumerable<ApplicationUserDto> positions) => _Mapper.Map<IEnumerable<ApplicationUser>>(positions);
    }
}
