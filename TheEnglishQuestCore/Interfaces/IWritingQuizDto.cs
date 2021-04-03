using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IWritingQuizDto
    {
        Task<bool> AddNewQuiz(WritingQuizDto quiz, string userId);
        Task<bool> RemoveQuiz(WritingQuizDto quiz);
        Task<WritingQuizDto> FindQuiz(int id);
        Task<WritingQuizDto> FindQuizByName(string name);
        Task<IEnumerable<WritingQuizDto>> GetAllQuizzesFiltered(string level);
        Task<IEnumerable<WritingQuizDto>> GetAllQuizzes();
        Task<bool> ModifyQuiz(WritingQuizDto quiz);
    }
}
