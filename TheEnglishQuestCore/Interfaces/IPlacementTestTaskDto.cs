using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheEnglishQuestCore
{
    public interface IPlacementTestTaskDto
    {
        Task<bool> DeletePosition(PlacementTestTaskDTO encPosition);
        Task<bool> AddNewPosition(PlacementTestTaskDTO encPosition);
        Task<PlacementTestTaskDTO> GetEntityById(int id);
        Task<IEnumerable<PlacementTestTaskDTO>> GetAllPositions();
       
    }
}
