using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IWritingQuizRepository
    {
        Task<bool> AddNewQuiz(WritingQuiz quiz, string userId);
        Task<bool> RemoveQuiz(WritingQuiz quiz);
        Task<WritingQuiz> FindQuiz(int id);
        Task<WritingQuiz> FindQuizByName(string name);
        Task<IEnumerable<WritingQuiz>> GetAllQuizzesFiltered(string level);
        IEnumerable<WritingQuiz> GetAllQuizzes();
        Task<bool> ModifyQuiz(WritingQuiz quiz);
    }
}
