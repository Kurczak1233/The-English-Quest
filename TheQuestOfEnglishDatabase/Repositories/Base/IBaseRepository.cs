using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheQuestOfEnglishDatabase
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        Task<bool> AddNew(Entity entity);
        Task<bool> Delete(Entity entity);
        List<Entity> GetAll();
        Task<bool> SaveChanges();
    }
}