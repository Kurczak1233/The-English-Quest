using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestDatabase
{
    public interface IEncouragementPositionRepository
    {
        Task<bool> Delete(EncouragementPosition entity);
        Task<bool> AddNew(EncouragementPosition entity);
        Task<IEnumerable<EncouragementPosition>> GetAllPositions();
    }
}