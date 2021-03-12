using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestCore.Interfaces;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore.Managers
{
    public class EncouragementPostitionManager : DTOManager<EncouragementPosition, EncouragementPositionDto>, IEncouragementPositionDto
    {
        public EncouragementPostitionManager(IEncouragementPositionRepository _enc, DTOMapper<EncouragementPosition, EncouragementPositionDto> mapper) : base(_enc, mapper)
        {

        }

        public async Task<bool> AddNewPosition(EncouragementPositionDto encPosition)
        {

            var entity = _DTOMapper.Map(encPosition); 
            return await _EncouragementPostionRepository.AddNew(entity);
        }

        public async Task<bool> DeletePosition(EncouragementPositionDto encPosition)
        {
            var entity = _DTOMapper.Map(encPosition);
            return await _EncouragementPostionRepository.Delete(entity);
        }

        public async Task<IEnumerable<EncouragementPositionDto>> GetAllPositions()
        {
            var encPositions = await _EncouragementPostionRepository.GetAllPositions();
            return _DTOMapper.Map(encPositions);
        }
    }
}
