using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore.Managers
{
    class GrammarQuizManager : DTOManager<GrammarQuiz, GrammarQuizDto>, IGrammarQuiz
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
