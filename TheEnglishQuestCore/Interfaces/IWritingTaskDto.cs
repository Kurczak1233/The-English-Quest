using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IWritingTaskDto : IBaseTaskDto<WritingTaskDto>
    {
        Task<WritingTaskDto> FindTask(int id);
        Task<bool> ModifyTask(WritingTaskDto obj);
    }
}
