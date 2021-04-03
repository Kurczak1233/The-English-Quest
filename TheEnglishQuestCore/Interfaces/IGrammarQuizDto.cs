using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public interface IGrammarQuizDto
    {
        Task<bool> AddNewQuiz(GrammarQuizDto quiz, string userId);
        Task<bool> RemoveQuiz(GrammarQuizDto quiz);
        Task<GrammarQuizDto> FindQuiz(int id);
        Task<GrammarQuizDto> FindQuizByName(string name);
        Task<IEnumerable<GrammarQuizDto>> GetAllQuizzesFiltered(string level);
        Task<IEnumerable<GrammarQuizDto>> GetAllQuizzes();
        Task<bool> ModifyQuiz(GrammarQuizDto quiz);
    }
}
