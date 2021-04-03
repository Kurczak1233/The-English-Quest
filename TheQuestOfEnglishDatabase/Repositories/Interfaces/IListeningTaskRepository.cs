using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IListeningTaskRepository : IBaseTaskRepository<ListeningTask>
    {
        Task<bool> ModifyTask(ListeningTask task);

        Task<ListeningTask> FindTask(int id);
    }
}
