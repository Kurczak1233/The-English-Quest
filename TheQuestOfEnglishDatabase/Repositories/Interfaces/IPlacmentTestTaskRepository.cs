using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public interface IPlacementTestTaskRepository : IBaseRepository<PlacementTestTask>
    {
        Task<bool> Delete(PlacementTestTask entity);
        Task<bool> AddNew(PlacementTestTask entity);
        Task<IEnumerable<PlacementTestTask>> GetAllValues();
        Task<PlacementTestTask> GetEntityById(int id);
        int GetCount();
    }
}