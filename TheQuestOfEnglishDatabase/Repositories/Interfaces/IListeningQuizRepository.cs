using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IListeningQuizRepository
    {
        Task<bool> AddNewQuiz(ListeningQuiz quiz, string userId);
        Task<bool> RemoveQuiz(ListeningQuiz quiz);
        Task<ListeningQuiz> FindQuiz(int id);
        Task<ListeningQuiz> FindQuizByName(string name);
        Task<IEnumerable<ListeningQuiz>> GetAllQuizzesFiltered(string level);
        IEnumerable<ListeningQuiz> GetAllQuizzes();
        Task<bool> ModifyQuiz(ListeningQuiz quiz);
    }
}
