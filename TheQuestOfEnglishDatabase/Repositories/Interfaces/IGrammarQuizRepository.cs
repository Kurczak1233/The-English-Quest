using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IGrammarQuizRepository
    {
        Task<bool> AddNewQuiz(GrammarQuiz quiz, string userId);
        Task<bool> RemoveQuiz(GrammarQuiz quiz);
        Task<GrammarQuiz> FindQuiz(int id);
        Task<GrammarQuiz> FindQuizByName(string name);


    }
}
