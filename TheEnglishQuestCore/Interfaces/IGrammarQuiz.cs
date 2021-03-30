using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public interface IGrammarQuiz
    {
        Task<bool> AddNewQuiz(GrammarQuizDto quiz, ApplicationUserDto user);
        Task<bool> RemoveQuiz(GrammarQuizDto quiz);
        Task<bool> FindQuiz(int id);
    }
}
