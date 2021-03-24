using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;

namespace TheEnglishQuestCore
{
    public class PlacementTestTaskManager : DTOManager<PlacementTestTask, PlacementTestTaskDTO>, IPlacementTestTaskDto
    {
        private readonly IPlacementTestTaskRepository _placementTestTaskRepository;
        public PlacementTestTaskManager(DTOMapper<PlacementTestTask, PlacementTestTaskDTO> mapper, IPlacementTestTaskRepository repo) : base(mapper)
        {
            _placementTestTaskRepository = repo;
        }
        public async Task<bool> AddNewPosition(PlacementTestTaskDTO encPosition)
        {

            var entity = _DTOMapper.Map(encPosition);
            return await _placementTestTaskRepository.AddNew(entity);
        }
        public async Task<PlacementTestTaskDTO> GetEntityById(int id)
        {
            var encPositions = await _placementTestTaskRepository.GetEntityById(id);
            return _DTOMapper.Map(encPositions);
        }
        public async Task<bool> DeletePosition(PlacementTestTaskDTO encPosition)
        {
            var entity = _DTOMapper.Map(encPosition);
            return await _placementTestTaskRepository.Delete(entity);
        }

        public async Task<IEnumerable<PlacementTestTaskDTO>> GetAllPositions()
        {
            var encPositions = await _placementTestTaskRepository.GetAllValues();
            return _DTOMapper.Map(encPositions);
        }

        public int GetCount()
        {
            return _placementTestTaskRepository.GetCount();
        }
    }
}
