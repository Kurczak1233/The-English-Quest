using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IGrammarQuizRepository
    {
        Task<bool> AddNewQuiz(GrammarQuiz quiz, string userId);
        Task<bool> RemoveQuiz(GrammarQuiz quiz);
        Task<GrammarQuiz> FindQuiz(int id);
        Task<GrammarQuiz> FindQuizByName(string name);
        Task<IEnumerable<GrammarQuiz>> GetAllQuizzesFiltered(string level);
        Task<IEnumerable<GrammarQuiz>> GetAllQuizzes();

    }
}
