using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEnglishQuestDatabase.Entities;
using TheEnglishQuestDatabase.Repositories.Interfaces;

namespace TheEnglishQuestCore
{
    public class DTOManager
    {
        private readonly IEncouragementPositionRepository _EncouragementPostionRepository;
        private readonly DTOMapper _DTOMapper;
        public DTOManager(IEncouragementPositionRepository _enc, DTOMapper mapper)
        {
            _DTOMapper = mapper;
            _EncouragementPostionRepository = _enc;
        }
        public List<EncouragementPositionDto> GetAllEncouagementPositons()
        {
            var encPositions = _EncouragementPostionRepository.GetAllPositions().ToList();
            return _DTOMapper.Map(encPositions);
        }
    }
}
