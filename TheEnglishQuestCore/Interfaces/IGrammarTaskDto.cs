using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IGrammarTaskDto : IBaseTaskDto<GrammarTaskDto>
    {
        Task<GrammarTaskDto> FindTask(int id);
        Task<bool> ModifyTask(GrammarTaskDto obj);
    }
}
