using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IWritingTaskRepository : IBaseTaskRepository<WritingTask>
    {
        Task<bool> ModifyTask(WritingTask task);

        Task<WritingTask> FindTask(int id);
    }
}
