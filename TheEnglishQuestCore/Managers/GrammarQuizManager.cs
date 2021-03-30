using System.Threading.Tasks;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class GrammarQuizManager : DTOManager<GrammarQuiz, GrammarQuizDto>, IGrammarQuiz
    {
        protected readonly IGrammarQuizRepository _GrammarQuizRepository;
        public GrammarQuizManager(DTOMapper<GrammarQuiz, GrammarQuizDto> mapper) : base(mapper)
        {
        }

        public async Task<bool> AddNewQuiz(GrammarQuizDto quiz)
        {
            var entity = _DTOMapper.Map(quiz);
            return await _GrammarQuizRepository.AddNewQuiz(entity);
        }

        public async Task<bool> FindQuiz(int id)
        {
            return await _GrammarQuizRepository.FindQuiz(id);
        }

        public async Task<bool> RemoveQuiz(GrammarQuizDto quiz)
        {
            var entity = _DTOMapper.Map(quiz);
            return await _GrammarQuizRepository.RemoveQuiz(entity);
        }
    }
}
