using System.Collections.Generic;
using System.Threading.Tasks;
using TheEnglishQuestDatabase;
using TheEnglishQuestDatabase.Entities;

namespace TheEnglishQuestCore
{
    public class DTOManager
    {
        protected readonly IEncouragementPositionRepository _EncouragementPostionRepository;
        protected readonly DTOMapper _DTOMapper;
        public DTOManager(IEncouragementPositionRepository _enc, DTOMapper mapper)
        {
            _DTOMapper = mapper;
            _EncouragementPostionRepository = _enc;
        }
    }
}
