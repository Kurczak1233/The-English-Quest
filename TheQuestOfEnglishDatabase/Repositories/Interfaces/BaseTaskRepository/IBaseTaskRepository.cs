using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestDatabase
{
    public interface IBaseTaskRepository<Entity>
    {
        Task<bool> Delete(Entity entity);
        Task<bool> AddNew(Entity entity);
        Task<IEnumerable<Entity>> GetAllValues();
    }
}
