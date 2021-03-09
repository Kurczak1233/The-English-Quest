using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase.Repositories.Interfaces;

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
            
            var entity = _DTOMapper.Map(encPosition);
            return await _EncouragementPostionRepository.AddNew(entity);
        }

        public async Task<bool> DeletePosition(EncouragementPositionDto encPosition)
        {
            var entity = _DTOMapper.Map(encPosition);
            return await _EncouragementPostionRepository.Delete(entity);
        }

        public  List<EncouragementPositionDto> GetAllPositions()
        {
            var encPositions =  _EncouragementPostionRepository.GetAllPositions().ToList();
            return  _DTOMapper.Map(encPositions);
        }
    }
}
