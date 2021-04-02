using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IBaseTaskDto<Entity>
    {
        Task<bool> Delete(Entity entity);
        Task<bool> AddNew(Entity entity);
        Task<IEnumerable<Entity>> GetAllValues();

        Task<Entity> FindTask(int id);
    }
}
