using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IReadingQuizDto
    {
        Task<bool> AddNewQuiz(ReadingQuizDto quiz, string userId);
        Task<bool> RemoveQuiz(ReadingQuizDto quiz);
        Task<ReadingQuizDto> FindQuiz(int id);
        Task<ReadingQuizDto> FindQuizByName(string name);
        Task<IEnumerable<ReadingQuizDto>> GetAllQuizzesFiltered(string level);
        Task<IEnumerable<ReadingQuizDto>> GetAllQuizzes();
        Task<bool> ModifyQuiz(ReadingQuizDto quiz);
    }
}
