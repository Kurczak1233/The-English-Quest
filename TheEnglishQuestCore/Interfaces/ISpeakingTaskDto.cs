using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface ISpeakingTaskDto : IBaseTaskDto<SpeakingTaskDto>
    {
        Task<SpeakingTaskDto> FindTask(int id);
        Task<bool> ModifyTask(SpeakingTaskDto obj);
    }
}
