using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class GrammarQuizManager : GrammarQuizMapper, IGrammarQuiz
    {
        protected readonly IGrammarQuizRepository _GrammarQuizRepository;
        protected readonly GrammarQuizMapper _grammarQuizMapper;
        public GrammarQuizManager(GrammarQuizMapper mapper, IGrammarQuizRepository grammarQuizRepository)
        {
            _grammarQuizMapper = mapper;
            _GrammarQuizRepository = grammarQuizRepository;
        }

        public async Task<bool> AddNewQuiz(GrammarQuizDto quiz, string userId)
        {
            //Dodać doktora tutaj i przerzucić go od razu do bazy?
            var entity = _grammarQuizMapper.Map(quiz);
            entity.UserId = userId;
            return await _GrammarQuizRepository.AddNewQuiz(entity, userId);
        }

        public async Task<GrammarQuizDto> FindQuiz(int id)
        {
            var entity = await _GrammarQuizRepository.FindQuiz(id);
            return _grammarQuizMapper.Map(entity);
        }

        public async Task<GrammarQuizDto> FindQuizByName(string name)
        {
           var entity = await _GrammarQuizRepository.FindQuizByName(name);
            return _grammarQuizMapper.Map(entity);
        }

        public async Task<bool> RemoveQuiz(GrammarQuizDto quiz)
        {
            var entity = _grammarQuizMapper.Map(quiz);
            return await _GrammarQuizRepository.RemoveQuiz(entity);
        }

        public async Task<IEnumerable<GrammarQuizDto>> GetAllQuizzes()
        {
            var entities = await _GrammarQuizRepository.GetAllQuizzes();
            return  _grammarQuizMapper.Map(entities);
            
        }
    }
}
