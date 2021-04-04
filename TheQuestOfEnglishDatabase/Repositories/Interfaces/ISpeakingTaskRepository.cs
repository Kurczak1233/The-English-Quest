using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface ISpeakingTaskRepository : IBaseTaskRepository<SpeakingTask>
    {
        Task<bool> ModifyTask(SpeakingTask task);

        Task<SpeakingTask> FindTask(int id);
    }
}
