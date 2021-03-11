using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheQuestOfEnglishDatabase
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<bool> AddNew(Entity entity);
        List<Entity> GetAll();
    }
}