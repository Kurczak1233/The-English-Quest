using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IListeningQuizDto
    {
        Task<bool> AddNewQuiz(ListeningQuizDto quiz, string userId);
        Task<bool> RemoveQuiz(ListeningQuizDto quiz);
        Task<ListeningQuizDto> FindQuiz(int id);
        Task<ListeningQuizDto> FindQuizByName(string name);
        Task<IEnumerable<ListeningQuizDto>> GetAllQuizzesFiltered(string level);
        Task<IEnumerable<ListeningQuizDto>> GetAllQuizzes();
        Task<bool> ModifyQuiz(ListeningQuizDto quiz);
    }
}
