using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    interface ISpeakingQuizDto
    {
        Task<bool> AddNewQuiz(SpeakingQuizDto quiz, string userId);
        Task<bool> RemoveQuiz(SpeakingQuizDto quiz);
        Task<SpeakingQuizDto> FindQuiz(int id);
        Task<SpeakingQuizDto> FindQuizByName(string name);
        Task<IEnumerable<SpeakingQuizDto>> GetAllQuizzesFiltered(string level);
        Task<IEnumerable<SpeakingQuizDto>> GetAllQuizzes();
        Task<bool> ModifyQuiz(SpeakingQuizDto quiz);
    }
}
