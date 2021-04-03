using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IReadingQuizRepository
    {
        Task<bool> AddNewQuiz(ReadingQuiz quiz, string userId);
        Task<bool> RemoveQuiz(ReadingQuiz quiz);
        Task<ReadingQuiz> FindQuiz(int id);
        Task<ReadingQuiz> FindQuizByName(string name);
        Task<IEnumerable<ReadingQuiz>> GetAllQuizzesFiltered(string level);
        IEnumerable<ReadingQuiz> GetAllQuizzes();
        Task<bool> ModifyQuiz(ReadingQuiz quiz);
    }
}
