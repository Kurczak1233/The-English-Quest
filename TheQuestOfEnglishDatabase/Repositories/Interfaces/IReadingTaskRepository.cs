using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IReadingTaskRepository : IBaseTaskRepository<ReadingTask>
    {
        Task<bool> ModifyTask(ReadingTask task);

        Task<ReadingTask> FindTask(int id);
    }

}
