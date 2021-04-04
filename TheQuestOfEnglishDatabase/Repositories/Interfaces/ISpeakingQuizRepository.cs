using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface ISpeakingQuizRepository
    {
        Task<bool> AddNewQuiz(SpeakingQuiz quiz, string userId);
        Task<bool> RemoveQuiz(SpeakingQuiz quiz);
        Task<SpeakingQuiz> FindQuiz(int id);
        Task<SpeakingQuiz> FindQuizByName(string name);
        Task<IEnumerable<SpeakingQuiz>> GetAllQuizzesFiltered(string level);
        IEnumerable<SpeakingQuiz> GetAllQuizzes();
        Task<bool> ModifyQuiz(SpeakingQuiz quiz);
    }
}
