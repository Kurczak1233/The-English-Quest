using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IReadingTaskDto : IBaseTaskDto<ReadingTaskDto>
    {
        Task<ReadingTaskDto> FindTask(int id);
        Task<bool> ModifyTask(ReadingTaskDto obj);
    }
}
