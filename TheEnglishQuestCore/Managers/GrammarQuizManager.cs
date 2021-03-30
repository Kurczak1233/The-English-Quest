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

        public async Task<bool> AddNewQuiz(GrammarQuizDto quiz)
        {
            var entity = _grammarQuizMapper.Map(quiz);
            return await _GrammarQuizRepository.AddNewQuiz(entity);
        }

        public async Task<bool> FindQuiz(int id)
        {
            return await _GrammarQuizRepository.FindQuiz(id);
        }

        public async Task<bool> RemoveQuiz(GrammarQuizDto quiz)
        {
            var entity = _grammarQuizMapper.Map(quiz);
            return await _GrammarQuizRepository.RemoveQuiz(entity);
        }
    }
}
