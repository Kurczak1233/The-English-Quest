using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class DTOManager : IDTOManager
    {
        private readonly IEncouragementPositionRepository _EncouragementPostionRepository;
        private readonly DTOMapper _DTOMapper;
        public DTOManager(IEncouragementPositionRepository _enc, DTOMapper mapper)
        {
            _DTOMapper = mapper;
            _EncouragementPostionRepository = _enc;
        }

        public async Task<bool> AddNewPosition(EncouragementPositionDto encPosition)
        {

            var entity = _DTOMapper.Map(encPosition); //Without await
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
            return  _DTOMapper.Map(encPositions);
        }
    }
}
