using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IListeningTaskDto : IBaseTaskDto<ListeningTaskDto>
    {
        Task<ListeningTaskDto> FindTask(int id);
        Task<bool> ModifyTask(ListeningTaskDto obj);
    }
}
