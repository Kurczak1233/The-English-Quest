using System.Threading.Tasks;
using TheEnglishQuestDatabase.Repositories.Interfaces;

namespace TheEnglishQuestDatabase
{
    public interface IGrammarTaskRepository : IBaseTaskRepository<GrammarTask>
    {
        Task<bool> ModifyTask(GrammarTask task);

        Task<GrammarTask> FindTask(int id);
    }
}
