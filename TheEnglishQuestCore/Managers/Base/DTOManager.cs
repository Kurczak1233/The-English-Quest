using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class DTOManager<Entity, EntityDto>
    {
        protected readonly IEncouragementPositionRepository _EncouragementPostionRepository;
        protected readonly DTOMapper<Entity, EntityDto> _DTOMapper;
        public DTOManager(IEncouragementPositionRepository _enc, DTOMapper<Entity, EntityDto> mapper)
        {
            _DTOMapper = mapper;
            _EncouragementPostionRepository = _enc;
        }
    }
}
